using UnityEngine;

public enum ItemType { PowerUp = 3, Boom, HP }

public class Item : MonoBehaviour
{
	[SerializeField]
	private ItemType itemType;
	private Movement2D movement2D;

	private void Awake()
	{
		movement2D = GetComponent<Movement2D>();
		if (movement2D == null)
		{
			Debug.LogError("Movement2D 컴포넌트를 찾을 수 없습니다.");
			return;
		}

		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);

		movement2D.MoveTo(new Vector3(x, y, 0));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Use(collision.gameObject);
			Destroy(gameObject);
		}
	}

	public void Use(GameObject player)
	{
		switch (itemType)
		{
			case ItemType.PowerUp:
				player.GetComponent<Weapon>().AttackLevel ++;
				break;
			case ItemType.Boom:
				player.GetComponent<Weapon>().BoomCount ++;
				break;
			case ItemType.HP:
				player.GetComponent<PlayerHP>().CurrentHP += 2;
				break;
		}
	}
}
