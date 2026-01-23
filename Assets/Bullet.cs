using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 10; // Tốc độ bay của đạn

    void Update()
    {
        // Làm đạn bay lên trên theo trục Y
        var newPosition = transform.position;
        newPosition.y += Time.deltaTime * flySpeed;
        transform.position = newPosition;
    }
}