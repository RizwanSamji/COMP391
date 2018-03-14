using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosionAsteroid;
    public GameObject explosionPlayer;

    private GameController gameControllerScript;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerScript == null)
        {
            Debug.Log("Cannot find Game Controller script on Object");
        }
    }
        void OnTriggerEnter2D(Collider2D other)
        {
        if(other.tag == "Boundary"||other.tag == "Hazard")
        {
            return;
        }

        if(other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            gameControllerScript.GameOver();
        }

        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
	
}
