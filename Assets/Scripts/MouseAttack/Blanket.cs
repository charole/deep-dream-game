using System.Collections;
using UnityEngine;

public class Blanket : MonoBehaviour
{
  private bool playerInRange = false;
  private float timer = 0f;
  private GameObject player;
  [SerializeField] private GameObject blackOverlayPrefab; // 검정색 오버레이 프리팹
  private Transform canvasTransform; // CanvasBlackOverlay의 Transform
  private GameObject blackOverlayInstance; // 검정색 오버레이 인스턴스

  private void Start()
  {
    Destroy(gameObject, 2f); // Blanket 오브젝트를 2초 뒤에 사라지게 함

    // blackOverlayPrefab이 할당되었는지 확인
    if (blackOverlayPrefab == null)
    {
      Debug.LogError("Black Overlay Prefab is not assigned in the inspector.");
    }

    // CanvasBlackOverlay를 찾아서 Transform을 설정
    Canvas[] canvases = FindObjectsOfType<Canvas>();
    foreach (Canvas canvas in canvases)
    {
      if (canvas.name == "CanvasBlackOverlay")
      {
        canvasTransform = canvas.transform;
        break;
      }
    }

    // canvasTransform이 할당되었는지 확인
    if (canvasTransform == null)
    {
      Debug.LogError("CanvasBlackOverlay not found in the scene.");
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && blackOverlayInstance == null)
    {
      playerInRange = true;
      player = other.gameObject;
      timer = 0f; // 타이머 초기화
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerInRange = false;
      timer = 0f;
    }
  }

  private void Update()
  {
    if (playerInRange && blackOverlayInstance == null)
    {
      timer += Time.deltaTime;
      if (timer >= 1f)
      {
        ActivateBlackOverlay();
      }
    }
    else
    {
      timer = 0f;
    }
  }

  private void ActivateBlackOverlay()
  {
    if (blackOverlayPrefab != null && canvasTransform != null)
    {
      blackOverlayInstance = Instantiate(blackOverlayPrefab, canvasTransform); // 캔버스의 자식으로 생성
      blackOverlayInstance.transform.localScale = Vector3.one; // 스케일 초기화
      blackOverlayInstance.GetComponent<BlackOverlay>().SetPlayer(player.transform);
    }
  }
}
