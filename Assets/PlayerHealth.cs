using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health // Kế thừa từ Health
{
    protected override void Die()
    {
        base.Die();
        Debug.Log("Player died");
        // Sau này có thể thêm logic "Game Over" ở đây
    }
}