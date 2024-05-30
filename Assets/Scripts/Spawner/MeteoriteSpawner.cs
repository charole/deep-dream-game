using System.Collections;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
  [SerializeField]
	private StageData stageData; // 스테이지 데이터
  [SerializeField]
	private GameObject alertLinePrefab; // 경고선 프리팹
	[SerializeField]
	private GameObject meteoritePrefab; // 생성할 유성 프리팹
	[SerializeField]
	private float minSpawnTime = 1.0f; // 최소 생성 주기
	[SerializeField]
	private float maxSpawnTime = 3.0f; // 최대 생성 주기

	private void Awake()
	{
		StartCoroutine("SpawnMeteorite");
	}

	private IEnumerator SpawnMeteorite()
	{
		while (true)
		{
			float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x); // x 좌표 랜덤 생성
			GameObject alertLine = Instantiate(alertLinePrefab, new Vector3(positionX, 0, 0), Quaternion.identity); // 경고선 생성

			yield return new WaitForSeconds(1.0f); // 1초 대기

			Destroy(alertLine); // 경고선 삭제
			Vector3 meteoritePosition = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
			Instantiate(meteoritePrefab, meteoritePosition, Quaternion.identity); // 유성 생성

			float spawnTime = Random.Range(minSpawnTime, maxSpawnTime); // 생성 주기 랜덤 설정
			
			yield return new WaitForSeconds(spawnTime); // 생성 주기만큼 대기
		}
	}
}
