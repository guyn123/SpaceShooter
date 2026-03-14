using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;

    // Hàm Reset tự động gọi khi bạn gắn script hoặc bấm Reset component
    private void Reset() => waypoints = GetComponentsInChildren<Waypoint>();
}