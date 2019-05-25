using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public ScoreManager scoreManager;
    public UIManager uiManager;

    public int health = 3;
    public int score;

    private bool _gameOver;

    private void Start() {
        player.OnDamageEvent += DecreaseHealth;
        scoreManager.OnScoreEvent += IncreaseScore;
        
        uiManager.SetHealthText(health);
        uiManager.SetScoreText(score);
        _gameOver = false;
    }

    private void Update() {

        if (!_gameOver) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && player.GetCurrentPosition() != PlayerController.Position.Top) {
                player.Move(player.GetCurrentPosition() + 1);
            } else if (Input.GetKeyDown(KeyCode.DownArrow) && player.GetCurrentPosition() != PlayerController.Position.Bottom) {
                player.Move(player.GetCurrentPosition() - 1);
            }
        }
        
    }

    private void DecreaseHealth(int dmg) {
        health -= dmg;
        uiManager.SetHealthText(health);

        if (health <= 0) {
            StopGame();
        }
        
    }

    private void IncreaseScore(int s) {
        if (!_gameOver) {
            score += s;
            uiManager.SetScoreText(score);
        }
    }

    private void StopGame() {
        _gameOver = true;
        uiManager.ShowGameOverOverlay();
        player.gameObject.SetActive(false);
            
    }
}
