using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector2 spawnValue;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //pause
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y,spawnValue.y));
                Quaternion spawnRotation = Quaternion.identity; //default rotation
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver)
            {
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        Debug.Log("Score is " + score);
    }

    public void GameOver()
    {
        Debug.Log("Game is Over");
        gameOver = true;
    }
}
