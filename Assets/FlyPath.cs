using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;

    private void Reset() => waypoints = GetComponentsInChildren<Waypoint>();

    // Hàm vẽ đường thẳng nối các Waypoint lại với nhau
    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        Gizmos.color = Color.green;
        // Chạy vòng lặp nối điểm i với điểm i+1
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }

    // Tạo Indexer để lấy nhanh tọa độ của một Waypoint (Trang 5)
    public Vector3 this[int index] => waypoints[index].transform.position;
}