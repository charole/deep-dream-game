using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    [TextArea] // Inspector에서 여러 줄 입력 가능하도록 설정
    private string dialogue;
    [SerializeField]
    private GameObject nextButton;  // 다음 버튼

    void Start()
    {
        nextButton.SetActive(false);  // 시작할 때 버튼을 숨김
        StartCoroutine(Typing(dialogue));
    }

    IEnumerator Typing(string talk)
    {
        text.text = null;
        for (int i = 0; i < talk.Length; i++)
        {
            text.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
        nextButton.SetActive(true);  // 타이핑이 완료되면 버튼을 보이게 함
    }
}
