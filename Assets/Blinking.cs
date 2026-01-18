using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start được gọi 1 lần khi bắt đầu game
    void Start()
    {
        // Lấy thành phần quản lý hình ảnh của ngọn lửa
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update được gọi liên tục mỗi khung hình
    void Update()
    {
        // Đảo ngược trạng thái hiển thị (Đang Bật -> Tắt, Đang Tắt -> Bật)
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}