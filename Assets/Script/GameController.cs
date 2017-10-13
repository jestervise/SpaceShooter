using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCounts;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    private bool restart;
    private bool gameOver;
    private float score;

    //Test code
    public float dieCount;

    //Test code 2
    public Text healthText;

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text="";
        gameOverText.text = "";
        StartCoroutine(SpawnWaves());
        ShowHealth();
    }

    public void SetGameOverText(string gameOverText) {
        this.gameOverText.text = gameOverText;
    }
    public void SetRestartText(string restartText)
    {
        this.restartText.text = restartText;
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKey(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int x = 0; x < hazardCounts; x++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver)
                {
                    restartText.text = "Press 'R' to restart";
                    restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);
            
        }
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: "+score;
    }

    public void ShowHealth() {
        healthText.text = "Health: " + dieCount;
    }

    

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
 


  
}
