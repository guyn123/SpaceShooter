using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health; // Máu của chính con địch này
    public int damage = 1;     // Sát thương gây ra cho người chơi

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem có va vào Player không
        var playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Trừ máu người chơi
            health.TakeDamage(1000);         // Địch tự sát (trừ 1000 máu để chết luôn)
        }
    }
}