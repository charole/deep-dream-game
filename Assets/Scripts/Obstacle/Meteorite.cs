using UnityEngine;

public class Meteorite : MonoBehaviour
{
	[SerializeField]
	private int damage = 2;
	[SerializeField]
	private GameObject explosionPrefab;
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
			playerController.ReduceSpeed(1f, 0f); // 1초 동안 이동 속도를 100%(0f)로 감소
			OnDie();
		}
	}

	public void OnDie()
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
