using System.Collections;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
	[SerializeField]
	private int maxHP = 10;
	private int currentHP;
	private SpriteRenderer spriteRenderer;
	private PlayerController playerController;

	public int MaxHP => maxHP;
	public int CurrentHP 
	{
		set => currentHP = Mathf.Clamp(value, 0, maxHP);
		get => currentHP;
	}

	private void Awake()
	{
		currentHP = maxHP;
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerController = GetComponent<PlayerController>();
	}

	public void TakeDamage(int damage)
	{
		currentHP -= damage;

		StopCoroutine("HitColorAnimation");
		StartCoroutine("HitColorAnimation");
		if (currentHP <= 0) {
			playerController.OnDie();
		}
	}

	private IEnumerator HitColorAnimation()
	{
		spriteRenderer.color = Color.red; // 플레이어 칼라를 빨간색으로 변경
		yield return new WaitForSeconds(0.1f);
		spriteRenderer.color = Color.white; // 플레이어 칼라를 원래 색으로 변경
	}
}
