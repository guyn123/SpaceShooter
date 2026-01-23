using UnityEngine;
using System.Collections;

public class PlayerShootingg : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval = 0.2f; // Thời gian giãn cách giữa 2 viên đạn
    private float lastBulletTime;

    void Update()
    {
        // Dùng GetMouseButton (giữ chuột) thay vì GetMouseButtonDown (nhấn 1 cái)
        if (Input.GetMouseButton(0))
        {
            // Kiểm tra xem đã đủ thời gian chờ chưa
            if (Time.time - lastBulletTime > shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}