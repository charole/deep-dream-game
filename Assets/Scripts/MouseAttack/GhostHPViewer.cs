using UnityEngine;
using UnityEngine.UI;

public class GhostHPViewer : MonoBehaviour
{
	private GhostHP ghostHP;
	private Slider hpSlider;

	public void Setup(GhostHP ghostHP)
	{
		this.ghostHP = ghostHP;
		hpSlider = GetComponent<Slider>();
	}

	private void Update()
	{
		hpSlider.value = ghostHP.CurrentHP / ghostHP.MaxHP;
	}
}
