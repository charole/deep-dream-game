using UnityEngine;
using UnityEngine.UI;

public class AmmoViewer : MonoBehaviour
{
	[SerializeField]
	private Ammo ammo;
	private Slider sliderAmmo;
	[SerializeField]
	private GameObject player; // 플레이어 오브젝트
	[SerializeField]
	private Vector3 offset; // 플레이어로부터 슬라이더의 오프셋
	private RectTransform sliderRectTransform;
	private Camera mainCamera;

	private void Awake()
	{
		sliderAmmo = GetComponent<Slider>();
		sliderRectTransform = sliderAmmo.GetComponent<RectTransform>();
		mainCamera = Camera.main;
	}

	private void Update()
	{
		sliderAmmo.value = ammo.CurrentAmmo / ammo.MaxAmmo;

		// 플레이어 옆에 슬라이더 배치
		Vector3 screenPosition = mainCamera.WorldToScreenPoint(player.transform.position + offset);
		sliderRectTransform.position = screenPosition;
	}
}