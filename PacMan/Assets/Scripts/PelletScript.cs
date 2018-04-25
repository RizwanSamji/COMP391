using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour {

    public GameObject blinky;
    private Animator anim;
    
	// Use this for initialization
	void Start () {
        anim = blinky.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            if (this.CompareTag("PowerPellet"))
            {            
                anim.SetBool("Scared", true);                                     
             }
        }

      
    }
    
}
