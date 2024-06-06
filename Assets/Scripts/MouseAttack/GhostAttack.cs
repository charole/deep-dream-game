using System.Collections;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
  [SerializeField]
  private GameObject ghostPrefab;
  [SerializeField]
  private GameObject ghostHPSliderPrefab;
  [SerializeField]
  private Transform canvasTransform;
  [SerializeField]
  private StageData stageData;
  [SerializeField]
  private float cooldownTime = 3f; // 유령 공격 쿨다운 시간

  private bool isCooldown = false;
  private float cooldownProgress = 1f; // 초기값을 1로 설정하여 슬라이더가 꽉 찬 상태로 시작

  public void CreateGhost(Vector3 position)
  {
    if (isCooldown) return;

    Vector3 spawnPosition = new Vector3(position.x, stageData.LimitMax.y, 0);
    GameObject ghost = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
    SpawnGhostHPSlider(ghost);
    StartCoroutine(CooldownCoroutine());
  }

  private void SpawnGhostHPSlider(GameObject ghost)
  {
    if (ghostHPSliderPrefab == null)
    {
      Debug.LogError("ghostHPSliderPrefab is not assigned.");
      return;
    }

    if (canvasTransform == null)
    {
      Debug.LogError("canvasTransform is not assigned.");
      return;
    }

    if (ghost.GetComponent<GhostHP>() == null)
    {
      Debug.LogError("GhostHP component is missing on the ghost object.");
      return;
    }

    GameObject sliderClone = Instantiate(ghostHPSliderPrefab);
    sliderClone.transform.SetParent(canvasTransform, false);
    sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(ghost.transform);
    sliderClone.GetComponent<GhostHPViewer>().Setup(ghost.GetComponent<GhostHP>());
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
