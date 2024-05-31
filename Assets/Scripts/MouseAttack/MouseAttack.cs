using System.Collections;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private GameObject previewPrefab;

    private GameObject previewInstance;

    private void Start()
    {
        // 마우스 위치에 불투명한 이미지를 표시하는 프리뷰 생성
        previewInstance = Instantiate(previewPrefab);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            StartCoroutine(SpawnObstacle(mousePosition));
        }
    }

    private IEnumerator SpawnObstacle(Vector3 position)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(obstacle);
    }
}
