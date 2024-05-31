using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
	[SerializeField]
	private int maxAmmo = 100; // 최대 탄창 용량
	[SerializeField]
	private int ammoRecoveryRate = 20; // 초당 회복되는 탄창 수
	[SerializeField]
	private float recoveryInterval = 1.0f; // 탄창 회복 간격

	private int currentAmmo; // 현재 탄창 용량
	
	public float MaxAmmo => maxAmmo;
	public int CurrentAmmo 
	{
		get => currentAmmo;
		set => currentAmmo = Mathf.Clamp(value, 0, maxAmmo);
	}

	private void Awake()
	{
		currentAmmo = maxAmmo; // 시작 시 최대 탄창 용량으로 설정
		StartCoroutine(RecoverAmmo()); // 탄창 회복 코루틴 시작
	}

	private IEnumerator RecoverAmmo()
	{
		while (true)
		{
			yield return new WaitForSeconds(recoveryInterval); // 설정한 간격만큼 대기
			CurrentAmmo += ammoRecoveryRate; // 탄창 회복
		}
	}

	public bool ConsumeAmmo(int amount)
	{
		if (currentAmmo >= amount)
		{
			CurrentAmmo -= amount;
			return true;
		}
		return false;
	}
}
