using System.Collections;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private GameObject ghostHPSliderPrefab; // 고스트 체력 슬라이더 프리팹
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private PreviewMouseAttack previewMouseAttack;
    [SerializeField]
    private Transform canvasTransform; // 캔버스 트랜스폼
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
        SpawnGhostHPSlider(obstacle); // 유령 체력 슬라이더 생성
    }

    private void SpawnGhostHPSlider(GameObject ghost)
    {
        GameObject sliderClone = Instantiate(ghostHPSliderPrefab); // 유령 체력 슬라이더 생성
        sliderClone.transform.SetParent(canvasTransform, false); // 캔버스 자식으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(ghost.transform); // 유령 체력 슬라이더 설정
        sliderClone.GetComponent<GhostHPViewer>().Setup(ghost.GetComponent<GhostHP>()); // 유령 체력 슬라이더 설정
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
