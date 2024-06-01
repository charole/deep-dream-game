using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameOverVideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer; // Video Player 컴포넌트 참조
    [SerializeField]
    private Button retryButton; // 다시하기 버튼 참조

    private void Start()
    {
        // 비디오 플레이어의 끝 이벤트에 대한 리스너 등록
        videoPlayer.loopPointReached += OnVideoEnd;
        retryButton.gameObject.SetActive(false); // 초기에는 버튼을 비활성화
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // 비디오 재생이 끝났을 때 버튼을 활성화
        retryButton.gameObject.SetActive(true);
    }
}
