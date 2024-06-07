using UnityEngine;

public class PreviewMouseAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject ghostPreviewPrefab;
  [SerializeField]
  private GameObject blanketPreviewPrefab;
  [SerializeField]
  private GameObject witchPreviewPrefab; // Witch 프리뷰 추가
  [SerializeField]
  private StageData stageData; // StageData 참조 추가
  [SerializeField]
  private GameObject verticalAlertLinePrefab; // 세로 가이드라인 프리팹
  [SerializeField]
  private GameObject horizontalAlertLinePrefab; // 가로 가이드라인 프리팹

  private GameObject previewInstance;
  private GameObject alertLineInstance;
  private AttackType currentAttackType;

  private void Awake()
  {
    UpdatePreview(AttackType.Ghost);
  }

  private void Update()
  {
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0f;

    if (previewInstance != null)
    {
      switch (currentAttackType)
      {
        case AttackType.Ghost:
          // Ghost 프리뷰의 경우 y 좌표를 고정
          mousePosition.y = stageData.LimitMax.y - 0.2f;
          UpdateAlertLine(mousePosition, true);
          break;
        case AttackType.Witch:
          // Witch 프리뷰의 경우 x 좌표를 고정하고 좌우 반전 적용
          mousePosition.x = mousePosition.x < Camera.main.transform.position.x ? stageData.LimitMin.x : stageData.LimitMax.x;
          SpriteRenderer previewSpriteRenderer = previewInstance.GetComponent<SpriteRenderer>();
          if (previewSpriteRenderer != null)
          {
            previewSpriteRenderer.flipX = mousePosition.x == stageData.LimitMin.x;
          }
          UpdateAlertLine(mousePosition, false);
          break;
        default:
          DestroyAlertLine();
          break;
      }
      previewInstance.transform.position = mousePosition;
    }
  }

  public void UpdatePreview(AttackType attackType)
  {
    if (previewInstance != null)
    {
      Destroy(previewInstance);
    }
    DestroyAlertLine();

    currentAttackType = attackType;

    switch (attackType)
    {
      case AttackType.Ghost:
        previewInstance = Instantiate(ghostPreviewPrefab);
        break;
      case AttackType.Blanket:
        previewInstance = Instantiate(blanketPreviewPrefab);
        break;
      case AttackType.Witch:
        previewInstance = Instantiate(witchPreviewPrefab); // Witch 프리뷰 인스턴스 생성
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
    if (alertLineInstance != null)
    {
      alertLineInstance.SetActive(isVisible);
    }
  }

  private void UpdateAlertLine(Vector3 position, bool isVertical)
  {
    if (alertLineInstance == null)
    {
      alertLineInstance = Instantiate(isVertical ? verticalAlertLinePrefab : horizontalAlertLinePrefab);
    }

    alertLineInstance.transform.position = position;
    alertLineInstance.SetActive(true);
  }

  private void DestroyAlertLine()
  {
    if (alertLineInstance != null)
    {
      Destroy(alertLineInstance);
      alertLineInstance = null;
    }
  }
}
