using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameExit : MonoBehaviour
{
	public void ExitGame()
	{
		Debug.Log("Game is exiting...");

		#if UNITY_EDITOR
			// Unity 에디터에서 실행 중인 경우
			EditorApplication.isPlaying = false;
		#else
			// 빌드된 게임에서 실행 중인 경우
			Application.Quit();
		#endif
	}
}