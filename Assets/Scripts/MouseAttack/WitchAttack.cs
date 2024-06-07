using System.Collections;
using UnityEngine;

public class WitchAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject witchPrefab;
  [SerializeField]
  private StageData stageData;
  [SerializeField]
  private float cooldownTime = 3f; // 쿨타임 설정
  // canvasTransform 필드는 제거

  private bool isCooldown = false;
  private float cooldownProgress = 1f; // 초기값을 1로 설정하여 슬라이더가 꽉 찬 상태로 시작

  public void CreateWitch(Vector3 mousePosition)
  {
    if (isCooldown)
    {
      return;
    }

    Vector3 spawnPosition;
    Vector3 moveDirection;
    bool flipX = false;

    if (mousePosition.x < Camera.main.transform.position.x)
    {
      // 마우스가 화면의 왼쪽에 클릭된 경우
      spawnPosition = new Vector3(stageData.LimitMin.x, mousePosition.y, 0);
      moveDirection = Vector3.right;
      flipX = true; // 왼쪽에서 오른쪽으로 이동할 때 좌우 반전
    }
    else
    {
      // 마우스가 화면의 오른쪽에 클릭된 경우
      spawnPosition = new Vector3(stageData.LimitMax.x, mousePosition.y, 0);
      moveDirection = Vector3.left;
    }

    GameObject witch = Instantiate(witchPrefab, spawnPosition, Quaternion.identity);
    witch.GetComponent<Movement2D>().MoveTo(moveDirection);

    // Witch의 SpriteRenderer를 좌우 반전
    SpriteRenderer witchSpriteRenderer = witch.GetComponent<SpriteRenderer>();
    if (witchSpriteRenderer != null)
    {
      witchSpriteRenderer.flipX = flipX;
    }

    StartCoroutine(CooldownCoroutine());
  }

  private IEnumerator CooldownCoroutine()
  {
    isCooldown = true;
    cooldownProgress = 0f;

    while (cooldownProgress < 1f)
    {
      cooldownProgress += Time.deltaTime / cooldownTime;
      yield return null;
    }

    isCooldown = false;
    cooldownProgress = 1f; // 쿨다운 완료 시 슬라이더를 다시 채웁니다.
  }

  public float GetCooldownProgress()
  {
    return cooldownProgress;
  }
}
