using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath; // Bản đồ đường bay
    public float flySpeed;  // Tốc độ bay
    private int nextIndex = 1; // Điểm đến tiếp theo (bắt đầu từ điểm số 1 vì sinh ra ở điểm 0)

    void Start()
    {
        // Khi vừa sinh ra, đặt máy bay đúng vào vị trí của Waypoint số 0
        if (flyPath != null) transform.position = flyPath[0];
    }

    void Update()
    {
        if (flyPath == null) return;

        // Hủy máy bay nếu đã bay hết đường (Trang 15)
        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        // Nếu chưa đến nơi thì tiếp tục bay
        if (transform.position != flyPath[nextIndex])
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]); // Xoay đầu máy bay hướng về đích (Trang 8)
        }
        else // Nếu đã đến nơi, chuyển mục tiêu sang điểm tiếp theo
        {
            nextIndex++;
        }
    }

    private void FlyToNextWaypoint()
    {
        // Hàm MoveTowards giúp di chuyển từ điểm A đến điểm B một cách mượt mà
        transform.position = Vector3.MoveTowards(transform.position, flyPath[nextIndex], flySpeed * Time.deltaTime);
    }

    // Hàm xoay đầu máy bay (Trang 8)
    private void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        var lookDirection = destination - position; // Hướng nhìn = Đích - Hiện tại
        if (lookDirection.magnitude < 0.01f) return;

        // Tính góc xoay
        var angle = Vector2.SignedAngle(Vector3.down, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}