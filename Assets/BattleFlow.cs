using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;
    public GameObject gameWinUI;
    public void ReturnToMainMenu() => SceneManager.LoadScene("MainMenu");
    private void Start()
    {
        gameOverUI.SetActive(false); // Ẩn màn hình Game Over khi mới chơi
        playerHealth.onDead += OnGameOver; // Lắng nghe sự kiện chết của người chơi
        gameWinUI.SetActive(false);

    }

    private void OnGameOver()
    {
        gameOverUI.SetActive(true); // Bật màn hình Game Over
        bgMusic.SetActive(false);   // Tắt nhạc nền
    }
    private void Update()
    {
        // Nếu số lượng địch <= 0 thì thắng
        if (EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }

    private void OnGameWin()
    {
        gameWinUI.SetActive(true); // Bật chữ You Win
        bgMusic.SetActive(false);  // Tắt nhạc
        playerHealth.gameObject.SetActive(false); // Ẩn phi thuyền người chơi
    }
}