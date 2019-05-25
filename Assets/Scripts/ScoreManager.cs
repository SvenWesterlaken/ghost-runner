using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int scoreIncrease;
    
    public event Action<int> OnScoreEvent;
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Obstacle")) {
            OnScoreEvent.Invoke(scoreIncrease);
        }
        
    }
}
