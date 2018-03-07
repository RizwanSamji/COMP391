using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosionAsteroid;
    // Use this for initialization
    void Start()
    {
    }
        void OnTriggerEnter2D(Collider2D other)
        {
        if(other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
	
}
