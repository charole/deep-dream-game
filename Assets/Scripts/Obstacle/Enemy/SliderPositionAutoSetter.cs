using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.up * 50.0f; // 오프셋 값
    private Transform targetTransform;
    private RectTransform rectTransform;
    private Camera mainCamera;

    public void Setup(Transform target)
    {
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main; // 메인 카메라 참조
    }

    private void LateUpdate()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 worldPosition = targetTransform.position + offset;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

        rectTransform.position = screenPosition;
    }
}
