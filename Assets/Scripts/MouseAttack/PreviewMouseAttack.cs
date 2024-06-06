using UnityEngine;

public class PreviewMouseAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject ghostPreviewPrefab;
  [SerializeField]
  private GameObject blanketPreviewPrefab;
  [SerializeField]
  private StageData stageData; // StageData 참조 추가
  private GameObject previewInstance;
  private bool isGhostPreview; // 유령 프리뷰 여부를 나타내는 플래그

  private void Awake()
  {
    UpdatePreview(AttackType.Ghost);
  }

  private void Update()
  {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0f;

    // 유령 프리뷰의 경우 y 좌표를 고정
    if (isGhostPreview)
    {
      mousePosition.y = stageData.LimitMax.y - 0.2f;
    }

    if (previewInstance != null)
    {
      previewInstance.transform.position = mousePosition;
    }
  }

  public void UpdatePreview(AttackType attackType)
  {
    if (previewInstance != null)
    {
      Destroy(previewInstance);
    }

    switch (attackType)
    {
      case AttackType.Ghost:
        previewInstance = Instantiate(ghostPreviewPrefab);
        isGhostPreview = true;
        break;
      case AttackType.Blanket:
        previewInstance = Instantiate(blanketPreviewPrefab);
        isGhostPreview = false;
        break;
    }

    SetPreviewVisibility(true);
  }

  public void SetPreviewVisibility(bool isVisible)
  {
    if (previewInstance != null)
    {
      previewInstance.SetActive(isVisible);
    }
  }
}
