using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackOverlay : MonoBehaviour
{
  private Transform player; // 플레이어를 할당합니다.
  private Material overlayMaterial;
  private RectTransform rectTransform;
  private Canvas canvas;

  private void Start()
  {
    overlayMaterial = GetComponent<Image>().material;
    rectTransform = GetComponent<RectTransform>();
    canvas = GetComponentInParent<Canvas>();
    StartCoroutine(DestroyAfterDelay(2f)); // 2초 후 사라지게 설정
  }

  private void Update()
  {
    if (player != null && overlayMaterial != null)
    {
      // Convert player world position to viewport position
      Vector2 viewportPos = Camera.main.WorldToViewportPoint(player.position);

      // Update shader properties
      overlayMaterial.SetVector("_CircleCenter", new Vector4(viewportPos.x, viewportPos.y, 0, 0));
      overlayMaterial.SetFloat("_CircleRadius", 0.2f); // Adjust the radius as needed (0.2f -> larger radius)
      overlayMaterial.SetFloat("_CircleFeather", 0.05f); // Adjust the feathering as needed
    }
  }

  public void SetPlayer(Transform playerTransform)
  {
    player = playerTransform;
  }

  private IEnumerator DestroyAfterDelay(float delay)
  {
    yield return new WaitForSeconds(delay);
    Destroy(gameObject);
  }
}
