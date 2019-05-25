using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text healthText;
    public Text scoreText;
    public GameObject gameOverOverlay;
    
    public void SetScoreText(int score) {
        scoreText.text = score.ToString();
    }

    public void SetHealthText(int health) {
        healthText.text = health.ToString();
    }

    public void ShowGameOverOverlay() {
        gameOverOverlay.SetActive(true);
    }
}
