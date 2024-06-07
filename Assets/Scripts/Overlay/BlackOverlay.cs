using System.Collections;
using UnityEngine;

public class BlackOverlay : MonoBehaviour
{
  private Transform player;
  private Transform playerMask;
  private SpriteRenderer playerSpriteRenderer;

  private void Start()
  {
    playerMask = transform.Find("PlayerMask");
    StartCoroutine(DestroyAfterDelay(1f)); // 1초 후 사라지게 설정
  }

  public void Initialize(Transform playerTransform, SpriteRenderer playerSR)
  {
    player = playerTransform;
    playerSpriteRenderer = playerSR;
    playerSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask; // 마스크 적용
  }

  private void Update()
  {
    if (player != null && playerMask != null)
    {
      Vector3 playerPos = player.position;
      playerMask.position = new Vector3(playerPos.x, playerPos.y, playerMask.position.z);
    }
  }

  private IEnumerator DestroyAfterDelay(float delay)
  {
    yield return new WaitForSeconds(delay);
    playerSpriteRenderer.maskInteraction = SpriteMaskInteraction.None; // 마스크 해제
    Destroy(gameObject);
  }
}
