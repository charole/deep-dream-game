using UnityEngine;
using UnityEngine.UI;

public class GhostHPViewer : MonoBehaviour
{
	private EnemyHP enemyHP;
	private Slider hpSlider;

	public void Setup(EnemyHP enemyHP)
	{
		this.enemyHP = enemyHP;
		hpSlider = GetComponent<Slider>();
	}

	private void Update()
	{
		hpSlider.value = enemyHP.CurrentHP / enemyHP.MaxHP;
	}
}
