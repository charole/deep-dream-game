using System.Collections;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
	[SerializeField]
	private GameObject obstaclePrefab;
	[SerializeField]
	private StageData stageData;
	[SerializeField]
	private PreviewMouseAttack previewMouseAttack;
	private float cooldownTime = 3f; // 쿨타임 설정
	private bool isCooldown = false;

	private void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0f;
		if (Input.GetMouseButtonDown(0) && !isCooldown)
		{
			CreateObstacle(mousePosition);
			StartCoroutine(CooldownCoroutine());
		}
	}

	private void CreateObstacle(Vector3 mousePosition)
	{
		Vector3 spawnPosition = new Vector3(mousePosition.x, stageData.LimitMax.y, 0);
		GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity); // 유령 객체를 스테이지 상단에서 생성
	}
	private IEnumerator CooldownCoroutine()
	{
		isCooldown = true;
		previewMouseAttack.SetPreviewVisibility(false); // 프리뷰 숨기기

		yield return new WaitForSeconds(cooldownTime);

		isCooldown = false;
		previewMouseAttack.SetPreviewVisibility(true); // 프리뷰 다시 보이기
	}
}
