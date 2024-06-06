using System.Collections;
using UnityEngine;

public class Blanket : MonoBehaviour
{
  private bool playerInRange = false;
  private float timer = 0f;
  private GameObject player;
  [SerializeField] private GameObject visionMaskPrefab; // 시야 제한을 위한 마스크 프리팹
  private GameObject visionMaskInstance;

  private void Start()
  {
    Destroy(gameObject, 2f); // Blanket 오브젝트를 2초 뒤에 사라지게 함
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerInRange = true;
      player = other.gameObject;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerInRange = false;
      timer = 0f;
      DestroyVisionMask();
    }
  }

  private void Update()
  {
    if (playerInRange)
    {
      timer += Time.deltaTime;
      if (timer >= 1f)
      {
        // 시야를 플레이어 주변만 보이게 하는 로직 추가
        RestrictVision();
      }
    }
    else
    {
      timer = 0f;
    }
  }

  private void RestrictVision()
  {
    // 시야를 플레이어 주변만 보이게 하는 로직 구현
    if (player == null)
    {
      Debug.LogError("Player is not assigned.");
      return;
    }

    if (visionMaskInstance == null)
    {
      visionMaskInstance = Instantiate(visionMaskPrefab, player.transform.position, Quaternion.identity);
      visionMaskInstance.transform.SetParent(player.transform);
    }
  }

  private void DestroyVisionMask()
  {
    if (visionMaskInstance != null)
    {
      Destroy(visionMaskInstance);
      visionMaskInstance = null;
    }
  }
}
