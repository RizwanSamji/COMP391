using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour {

    public float speed = 0.4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
    bool valid(Vector2 dir)
    {
        Vector2 pacPos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pacPos + dir, pacPos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
