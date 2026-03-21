using UnityEngine;

// Khai báo cấu trúc của một Đợt tấn công (Wave)
[System.Serializable]
public class EnemyWave
{
    public Transform enemyPrefab;     // Loại máy bay địch (Xanh, Đỏ...)
    public int numberOfEnemy;         // Số lượng sinh ra trong đợt này
    public Vector3 formationOffset;   // Khoảng cách giãn cách giữa các máy bay
    public FlyPath flyPath;           // Bay theo đường nào
    public float speed;               // Tốc độ bay
    public float nextWaveDelay;       // Sau bao nhiêu giây thì ra đợt tiếp theo
}

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] enemyWaves; // Danh sách các đợt tấn công
    private int currentWave;       // Đợt hiện tại

    void Start() => SpawnEnemyWave(); // Vừa vào game là đẻ ngay đợt 1

    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.flyPath[0]; // Điểm đẻ là Waypoint số 0

        // Chạy vòng lặp để sinh ra đủ số lượng máy bay
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            // Đẻ ra 1 cái máy bay
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);

            // Lấy ông phi công ra để giao nhiệm vụ
            var agent = enemy.GetComponent<FlyPathAgent>();
            agent.flyPath = waveInfo.flyPath;   // Giao bản đồ
            agent.flySpeed = waveInfo.speed;    // Giao tốc độ

            // Dịch chuyển vị trí đẻ ra một chút để máy bay sau không đè lên máy bay trước
            startPosition += waveInfo.formationOffset;
        }

        currentWave++; // Chuyển sang đợt tiếp theo
        if (currentWave < enemyWaves.Length)
        {
            // Đặt lịch hẹn tự động gọi lại hàm này sau 'nextWaveDelay' giây
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }
    }
}