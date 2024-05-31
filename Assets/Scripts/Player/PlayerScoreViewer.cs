using UnityEngine;
using TMPro;

public class PlayerScoreViewer : MonoBehaviour
{
	[SerializeField]
	private PlayerController playerController;
	private TextMeshProUGUI textScore;

	private void Awake()
	{
		textScore = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		textScore.text = "점수 " + playerController.Score;
	}
}
