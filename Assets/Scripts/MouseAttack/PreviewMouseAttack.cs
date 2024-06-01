using UnityEngine;

public class PreviewMouseAttack : MonoBehaviour
{
	[SerializeField]
	private GameObject obstaclePrefab;
	private GameObject previewInstance;

	private void Awake()
	{
		previewInstance = Instantiate(obstaclePrefab);
		SetPreviewVisibility(true);
	}

	private void Update()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0f;
		previewInstance.transform.position = mousePosition;
	}

	public void SetPreviewVisibility(bool isVisible)
	{
		previewInstance.SetActive(isVisible);
	}
}