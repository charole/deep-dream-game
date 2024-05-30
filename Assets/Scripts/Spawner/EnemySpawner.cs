using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField]
	private StageData stageData; // 스테이지 데이터
  [SerializeField]
	private GameObject enemyPrefab; // 생성할 적 프리팹
	[SerializeField]
	private GameObject enemyHPSliderPrefab; // 적 체력 슬라이더 프리팹
	[SerializeField]
	private Transform canvasTransform; // 캔버스 트랜스폼
	[SerializeField]
	private float spawnTime; // 생성 주기

	private void Awake()
	{
		StartCoroutine("SpawnEnemy");
	}

	private IEnumerator SpawnEnemy()
	{
		while (true)
		{
			float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x); // x 좌표 랜덤 생성
			Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0); // 생성 위치
			GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity); // 적 생성
			SpawnEnemyHPSlider(enemyClone); // 적 체력 슬라이더 생성
			yield return new WaitForSeconds(spawnTime); // 생성 주기만큼 대기			
		}
	}

	private void SpawnEnemyHPSlider(GameObject enemy)
	{
		GameObject sliderClone = Instantiate(enemyHPSliderPrefab); // 적 체력 슬라이더 생성
		sliderClone.transform.SetParent(canvasTransform); // 캔버스 자식으로 설정
		sliderClone.transform.localScale = Vector3.one; // 스케일 초기화
		sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform); // 적 체력 슬라이더 설정
		sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>()); // 적 체력 슬라이더 설정
	}
}
