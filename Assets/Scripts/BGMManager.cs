using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
  private static BGMManager instance;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
      SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때마다 호출되는 이벤트 등록
    }
    else
    {
      Destroy(gameObject);
    }
  }

  private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    // 특정 씬 이름과 비교하여 BGMManager 오브젝트를 파괴할지 결정
    if (scene.name != "Intro" && scene.name != "GameGuide1" && scene.name != "GameGuide2" && scene.name != "GameGuide3")
    {
      Destroy(gameObject);
    }
  }

  void OnDestroy()
  {
    // 이벤트 등록 해제
    SceneManager.sceneLoaded -= OnSceneLoaded;
  }
}
