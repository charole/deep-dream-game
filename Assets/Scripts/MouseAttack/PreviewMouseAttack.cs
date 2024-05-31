using UnityEngine;

public class PreviewMouseAttack : MonoBehaviour
{
    [SerializeField]
    private Sprite obstacleSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacleSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f); // 불투명하게 설정
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;
    }
}
