using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab; // Hiệu ứng nổ
    public int defaultHealthPoint;     // Máu mặc định
    public System.Action onDead;
    public System.Action onHealthChanged;
    public int healthPoint;

    private void Start()
    {
        healthPoint = defaultHealthPoint; // Gán máu khi bắt đầu
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;
        healthPoint -= damage;
        onHealthChanged?.Invoke(); // Báo hiệu máu bị trừ
        if (healthPoint <= 0) Die();
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
        onDead?.Invoke();
    }
}