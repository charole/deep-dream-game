using System.Collections;
using UnityEngine;

public class GhostHP : MonoBehaviour
{
	[SerializeField]
	private float maxHP = 10;
	private float currentHP;
	private Ghost ghost;
	private SpriteRenderer spriteRenderer;

	public float MaxHP => maxHP;
	public float CurrentHP => currentHP;

	private void Awake()
	{
		currentHP = maxHP;
		ghost = GetComponent<Ghost>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void TakeDamage(float damage)
	{
		currentHP -= damage;
		StopCoroutine("HitColorAnimation");
		StartCoroutine("HitColorAnimation");
		if (currentHP <= 0)
		{
			ghost.OnDie(true);
		}
	}

	private IEnumerator HitColorAnimation()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.05f);
		spriteRenderer.color = Color.white;
	}
}
