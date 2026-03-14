using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;
    private float originalWidth;

    void Start()
    {
        // Lưu lại chiều dài ban đầu của thanh máu
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        // Lắng nghe sự kiện mất máu
        health.onHealthChanged += UpdateHealthValue;
    }

    private void UpdateHealthValue()
    {
        // Tính toán tỷ lệ phần trăm máu còn lại
        float scale = (float)health.healthPoint / health.defaultHealthPoint;
        // Cắt bớt chiều dài của Mask tương ứng với tỷ lệ máu
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
}