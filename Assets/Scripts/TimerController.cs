using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI timerText; // TextMeshProUGUI 사용
  [SerializeField]
  private string clearSceneName = "GameClearScene"; // 게임 클리어 씬 이름

  private float timeRemaining = 180f; // 3분 (180초)
  private bool timerIsRunning = false;

  private void Start()
  {
    timerIsRunning = true;
    UpdateTimerText();
  }

  private void Update()
  {
    if (timerIsRunning)
    {
      if (timeRemaining > 0)
      {
        timeRemaining -= Time.deltaTime;
        UpdateTimerText();
      }
      else
      {
        timeRemaining = 0;
        timerIsRunning = false;
        GameClear();
      }
    }
  }

  private void UpdateTimerText()
  {
    int minutes = Mathf.FloorToInt(timeRemaining / 60);
    int seconds = Mathf.FloorToInt(timeRemaining % 60);
    timerText.text = $"남은시간 {minutes:0}:{seconds:00}";
  }

  private void GameClear()
  {
    SceneManager.LoadScene(clearSceneName);
  }
}
