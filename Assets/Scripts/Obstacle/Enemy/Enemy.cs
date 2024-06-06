using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private int damage = 1;
	[SerializeField]
	private int scorePoint = 100;
	[SerializeField]
	private GameObject explosionPrefab;
	[SerializeField]
	private GameObject[] itemPrefabs;
	private PlayerController playerController;

	private void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerHP>().TakeDamage(damage);
			playerController.ReduceSpeed(2f, 2.5f); // 2초 동안 이동 속도를 50%(2.5f)로 감소
			OnDie();
		}
	}

	public void OnDie()
	{
		playerController.Score += scorePoint;
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		SpawnItem();
		Destroy(gameObject);
	}

	private void SpawnItem()
	{
		int spawnItem = Random.Range(0, 100);
		if (spawnItem < 0)
		{
			Instantiate(itemPrefabs[0], transform.position, Quaternion.identity); //TODO: power up item 적용 여부 고민 중이라 0으로 설정
		}
		else if (spawnItem < 5)
		{
			Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
		}
		else if (spawnItem < 10)
		{
			Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
		}
	}
}
