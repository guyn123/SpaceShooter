using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Update được gọi liên tục mỗi khung hình
    void Update()
    {
        // 1. Lấy vị trí chuột và đổi từ Tọa độ màn hình (Screen) sang Tọa độ game (World)
        var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. Đặt lại Z = 0 (Bắt buộc vì đây là game 2D phẳng)
        worldPoint.z = 0;

        // 3. Gán vị trí của tàu vào vị trí mới vừa tính toán
        transform.position = worldPoint;
    }
}