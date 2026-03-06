//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyHealth : MonoBehaviour
//{
//    public GameObject explosionPrefab;
//    private void OnTriggerEnter2D(Collider2D collision) => Die();
//    private void Die()
//    {
//        var explosion = Instantiate(explosionPrefab, transform.position,
//       transform.rotation);
//        Destroy(explosion, 1);
//        Destroy(gameObject);
//    }
//}


//using UnityEngine;

//public class EnemyHealth : Health // Kế thừa từ Health
//{
//    // Ghi đè hàm Die để in ra log riêng
//    protected override void Die()
//    {
//        base.Die(); // Gọi hàm Die gốc của cha (để nổ và xóa)
//        Debug.Log("Enemy died");
//    }
//}

public class EnemyHealth : Health
{
    // Biến static để đếm tổng số địch đang sống
    public static int LivingEnemyCount;

    // Khi địch sinh ra, tăng số lượng lên 1
    private void Awake() => LivingEnemyCount++;

    protected override void Die()
    {
        LivingEnemyCount--; // Khi địch chết, giảm số lượng đi 1
        base.Die();
    }
}