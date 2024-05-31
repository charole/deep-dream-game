using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
	[SerializeField]
	private StageData stageData;
	private float destroyWeight = 2.0f;

	private void LateUpdate()
	{
		if (transform.position.y < stageData.LimitMin.y - destroyWeight)
		{
			Destroy(gameObject);
			if (gameObject.CompareTag("Ghost")) 
				gameObject.GetComponent<Ghost>().OnDie(); // 유령이 맨 밑으로 떨어지면 OnDie 호출
		}
		else if (transform.position.y > stageData.LimitMax.y + destroyWeight)
			Destroy(gameObject);
		else if (transform.position.x < stageData.LimitMin.x - destroyWeight)
			Destroy(gameObject);
		else if (transform.position.x > stageData.LimitMax.x + destroyWeight)
			Destroy(gameObject);
	}
}
