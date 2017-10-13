using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour {
    public GameObject astroidexplosions;
    public GameObject playerExplosions;
    float countdownTime = 3;
    public int scoreValue;
    private GameController gameController;

    

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        if (gameControllerObject == null)
            Debug.Log("The game controller object is not not found");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shot")
        {
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject explode = Instantiate(astroidexplosions, transform.position, transform.rotation) as GameObject;
            Destroy(explode, 0.5f);
        }
        else if (other.tag == "Player")
        {
            //Testcode
            gameController.dieCount--;
            gameController.ShowHealth();
            Destroy(gameObject);
            GameObject explode = Instantiate(playerExplosions, transform.position, transform.rotation) as GameObject;
            Destroy(explode, 0.5f);
            //
            //Test
            if (gameController.dieCount <= 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                explode = Instantiate(playerExplosions, transform.position, transform.rotation) as GameObject;
                Destroy(explode, 0.5f);
                gameController.GameOver();
            }
        }
      
        
    }
   

    
}
