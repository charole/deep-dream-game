using UnityEngine;

public class Ghost : MonoBehaviour
{
	[SerializeField]
	private int damage = 3;
	[SerializeField]
	private GameObject explosionPrefab;
	private GameObject playerObject;

	private void Awake()
	{
		// 플레이어 오브젝트를 태그로 찾아 할당
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}

	public void OnDie(bool notDamage = false)
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		if (notDamage == false)
		{
			playerObject.GetComponent<PlayerHP>().TakeDamage(damage); // 플레이어 체력 감소
		}
		Destroy(gameObject);
	}
}
