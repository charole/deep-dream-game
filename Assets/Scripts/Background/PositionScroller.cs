using UnityEngine;

public class PositionScroller : MonoBehaviour
{
	[SerializeField]
  private Transform target;
	[SerializeField]
	private float scrollRange = 30.2f;
	[SerializeField]
	private float moveSpeed = 3.0f;
	[SerializeField]
	private Vector3 moveDirection = Vector3.down;

	private void Update()
	{
		// 배경이 moveDirection 방향으로 moveSpeed 속도로 이동
		transform.position += moveDirection * moveSpeed * Time.deltaTime;

		// 배경이 scrollRange 이하로 내려가면 target 위치로 이동
		if (transform.position.y <= -scrollRange)
		{
			transform.position = target.position + Vector3.up * scrollRange;
		}
	}
}
