using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab; // Hiệu ứng nổ
    public int defaultHealthPoint;     // Máu mặc định
    private int healthPoint;

    private void Start()
    {
        healthPoint = defaultHealthPoint; // Gán máu khi bắt đầu
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage; // Trừ máu

        if (healthPoint <= 0)
        {
            Die(); // Hết máu thì gọi hàm chết
        }
    }

    // Hàm ảo (virtual) để con cái có thể viết lại (override)
    protected virtual void Die()
    {
        // Tạo hiệu ứng nổ
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1);
        }
        Destroy(gameObject); // Xóa đối tượng
    }
}