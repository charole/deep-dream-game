using UnityEngine;
using UnityEngine.UI;

public class MouseAttack : MonoBehaviour
{
  [SerializeField]
  private GhostAttack ghostAttack;
  [SerializeField]
  private BlanketAttack blanketAttack;
  [SerializeField]
  private WitchAttack witchAttack; // WitchAttack 추가
  [SerializeField]
  private PreviewMouseAttack previewMouseAttack;
  [SerializeField]
  private Image attackTypeImage; // 공격 수단 이미지 UI
  [SerializeField]
  private Sprite ghostSprite; // 유령 공격 수단 이미지
  [SerializeField]
  private Sprite blanketSprite; // 이불 공격 수단 이미지
  [SerializeField]
  private Sprite witchSprite; // Witch 공격 수단 이미지 추가
  [SerializeField]
  private Slider cooldownSlider; // 쿨타임 슬라이더 UI

  private AttackType currentAttackType = AttackType.Ghost;
  private int attackTypeCount;

  private void Start()
  {
    attackTypeCount = System.Enum.GetNames(typeof(AttackType)).Length;
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
      if (Input.mouseScrollDelta.y > 0)
      {
        // 마우스 휠을 올릴 때 이전 아이템 선택
        currentAttackType = (AttackType)(((int)currentAttackType - 1 + attackTypeCount) % attackTypeCount);
      }
      else if (Input.mouseScrollDelta.y < 0)
      {
        // 마우스 휠을 내릴 때 다음 아이템 선택
        currentAttackType = (AttackType)(((int)currentAttackType + 1) % attackTypeCount);
      }
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
      case AttackType.Witch:
        witchAttack.CreateWitch(mousePosition); // Witch 공격 추가
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
      case AttackType.Witch:
        attackTypeImage.sprite = witchSprite; // Witch 이미지 추가
        break;
    }
  }

  private void UpdateCooldownSlider()
  {
    float cooldownProgress = 1f; // 기본값으로 1을 설정 (쿨타임이 없는 경우)

    switch (currentAttackType)
    {
      case AttackType.Ghost:
        cooldownProgress = ghostAttack.GetCooldownProgress();
        break;
      case AttackType.Blanket:
        cooldownProgress = blanketAttack.GetCooldownProgress();
        break;
      case AttackType.Witch:
        cooldownProgress = witchAttack.GetCooldownProgress();
        break;
    }

    cooldownSlider.value = cooldownProgress;
  }
}
