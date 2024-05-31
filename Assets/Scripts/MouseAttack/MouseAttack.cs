using System.Collections;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
	[SerializeField]
	private GameObject obstaclePrefab;
	[SerializeField]
	private StageData stageData;
	private GameObject previewInstance;

	private void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0f;
		if (Input.GetMouseButtonDown(0))
		{
			CreateObstacle(mousePosition);
		}
	}

	private void CreateObstacle(Vector3 mousePosition)
	{
		Vector3 spawnPosition = new Vector3(mousePosition.x, stageData.LimitMax.y, 0);
		GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity); // 유령 객체를 스테이지 상단에서 생성
	}
}
