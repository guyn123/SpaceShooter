//using UnityEngine;
//using System.Collections;

//public class Bullet : MonoBehaviour
//{
//    public float flySpeed = 10; // Tốc độ bay của đạn

//    void Update()
//    {
//        // Làm đạn bay lên trên theo trục Y
//        var newPosition = transform.position;
//        newPosition.y += Time.deltaTime * flySpeed;
//        transform.position = newPosition;
//    }
//}
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 10;
    public int damage = 1; // Sát thương của đạn

    // ... (Giữ nguyên phần Update bay lên) ...
    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Thử lấy component EnemyHealth từ đối tượng va chạm
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Gây sát thương
        }

        Destroy(gameObject); // Xóa viên đạn
    }
}