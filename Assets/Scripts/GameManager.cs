using UnityEngine;

public class GameManager : MonoBehaviour
{
  void Start()
  {
    SetResolution();
  }

  void SetResolution()
  {
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;

    // 16:9 비율 유지
    float targetAspect = 16.0f / 9.0f;
    float windowAspect = (float)screenWidth / (float)screenHeight;
    float scaleHeight = windowAspect / targetAspect;

    if (scaleHeight < 1.0f)
    {
      int adjustedWidth = Mathf.RoundToInt(screenWidth / scaleHeight);
      Screen.SetResolution(adjustedWidth, screenHeight, true);
    }
    else
    {
      int adjustedHeight = Mathf.RoundToInt(screenHeight * scaleHeight);
      Screen.SetResolution(screenWidth, adjustedHeight, true);
    }
  }
}
