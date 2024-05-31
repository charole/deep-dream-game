using UnityEngine;
using UnityEngine.UI;

public class AmmoViewer : MonoBehaviour
{
	[SerializeField]
	private Ammo ammo;
	private Slider sliderAmmo;

	private void Awake()
	{
		sliderAmmo = GetComponent<Slider>();
	}

	private void Update()
	{
		sliderAmmo.value = ammo.CurrentAmmo / ammo.MaxAmmo;
	}
}
