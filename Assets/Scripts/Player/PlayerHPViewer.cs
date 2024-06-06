using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private GameObject hpImagePrefab; // HP 이미지 프리팹
    [SerializeField]
    private Transform hpImageParent; // HP 이미지를 담을 부모 객체
    [SerializeField]
    private float spacing = 10f; // 이미지 간의 간격

    private GameObject[] hpImages;

    private void Start()
    {
        InitializeHPImages();
    }

    private void Update()
    {
        UpdateHPImages();
    }

    private void InitializeHPImages()
    {
        // 현재 HP 이미지를 담을 배열 초기화
        hpImages = new GameObject[(int)playerHP.MaxHP];

        for (int i = 0; i < playerHP.MaxHP; i++)
        {
            // HP 이미지를 생성하고 부모 객체에 추가
            GameObject hpImage = Instantiate(hpImagePrefab, hpImageParent);
            // 이미지의 위치를 설정
            RectTransform rectTransform = hpImage.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(i * (rectTransform.sizeDelta.x + spacing), 0);
            hpImages[i] = hpImage;
        }
    }

    private void UpdateHPImages()
    {
        for (int i = 0; i < hpImages.Length; i++)
        {
            // 현재 HP에 따라 이미지 활성화/비활성화
            hpImages[i].SetActive(i < playerHP.CurrentHP);
        }
    }
}
