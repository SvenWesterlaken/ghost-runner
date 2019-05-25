using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour {

    public GameObject[] obstaclePatterns;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    
    private int _pLength;

    private void Start() {
        _pLength = obstaclePatterns.Length;
        StartCoroutine(nameof(ObstacleSpawn));
    }

    private IEnumerator ObstacleSpawn() {

        while (true) {
            var rand = Random.Range(0, _pLength);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
        
            if (startTimeBtwSpawn >= minTime) {
                startTimeBtwSpawn -= decreaseTime;
            }
            
            yield return new WaitForSeconds(startTimeBtwSpawn);
        }
    }
}
