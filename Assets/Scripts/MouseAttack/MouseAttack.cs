using UnityEngine;
using UnityEngine.UI;

public class MouseAttack : MonoBehaviour
{
  [SerializeField]
  private GhostAttack ghostAttack;
  [SerializeField]
  private BlanketAttack blanketAttack;
  [SerializeField]
  private PreviewMouseAttack previewMouseAttack;
  [SerializeField]
  private Image attackTypeImage; // 공격 수단 이미지 UI
  [SerializeField]
  private Sprite ghostSprite; // 유령 공격 수단 이미지
  [SerializeField]
  private Sprite blanketSprite; // 이불 공격 수단 이미지
  [SerializeField]
  private Slider cooldownSlider; // 쿨타임 슬라이더 UI

  private AttackType currentAttackType = AttackType.Ghost;

  private void Start()
  {
    UpdateAttackTypeUI();
    UpdateCooldownSlider(); // 슬라이더 초기화
  }

  private void Update()
  {
    HandleAttackSelection();
    UpdateCooldownSlider();

    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0f;

    if (Input.GetMouseButtonDown(0))
    {
      CreateObstacle(mousePosition);
    }
  }

  private void HandleAttackSelection()
  {
    if (Input.mouseScrollDelta.y != 0)
    {
      currentAttackType = (AttackType)(((int)currentAttackType + 1) % 2);
      UpdatePreview();
      UpdateAttackTypeUI();
    }
  }

  private void UpdatePreview()
  {
    previewMouseAttack.UpdatePreview(currentAttackType);
  }

  private void CreateObstacle(Vector3 mousePosition)
  {
    switch (currentAttackType)
    {
      case AttackType.Ghost:
        ghostAttack.CreateGhost(mousePosition);
        break;
      case AttackType.Blanket:
        blanketAttack.CreateBlanket(mousePosition);
        break;
    }
  }

  private void UpdateAttackTypeUI()
  {
    switch (currentAttackType)
    {
      case AttackType.Ghost:
        attackTypeImage.sprite = ghostSprite;
        break;
      case AttackType.Blanket:
        attackTypeImage.sprite = blanketSprite;
        break;
    }
  }

  private void UpdateCooldownSlider()
  {
    float cooldownProgress = 0f;

    switch (currentAttackType)
    {
      case AttackType.Ghost:
        cooldownProgress = ghostAttack.GetCooldownProgress();
        break;
      case AttackType.Blanket:
        cooldownProgress = blanketAttack.GetCooldownProgress();
        break;
    }

    cooldownSlider.value = cooldownProgress;
  }
}
