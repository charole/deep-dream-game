using System.Collections;
using UnityEngine;

public class BlanketAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject blanketPrefab;
  [SerializeField]
  private Transform canvasTransform;
  [SerializeField]
  private StageData stageData;
  [SerializeField]
  private float cooldownTime = 3f; // 이불 공격 쿨다운 시간

  private bool isCooldown = false;
  private float cooldownProgress = 1f; // 초기값을 1로 설정하여 슬라이더가 꽉 찬 상태로 시작

  public void CreateBlanket(Vector3 position)
  {
    if (isCooldown) return;

    Vector3 spawnPosition = new Vector3(position.x, position.y, 0); // 클릭한 위치에 생성
    Instantiate(blanketPrefab, spawnPosition, Quaternion.identity);
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
