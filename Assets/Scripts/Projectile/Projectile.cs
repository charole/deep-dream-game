using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField]
	private float damage = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			collision.GetComponent<EnemyHP>().TakeDamage(damage);
			Destroy(gameObject);
		}
		if (collision.CompareTag("Ghost"))
		{
			collision.GetComponent<GhostHP>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
