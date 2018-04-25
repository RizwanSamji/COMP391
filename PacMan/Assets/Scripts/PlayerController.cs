using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}

    public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private Rigidbody2D rBody;
 

	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
	}



    // Used when performing physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1 whenever left, right, a, or d is pushed
        float moveVertical = Input.GetAxis("Vertical"); // Reutn a value between -1 and 1 whenever up, down, w, or s is pushed

        // Debug.Log("H= " + moveHorizontal + " V= " + moveVertical);
     
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
      
        // Establishes a "connection" to the rigidbody2D component
        rBody.velocity = movement * speed;

        // rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, -8.5f, 3f),Mathf.Clamp(rBody.position.y, -4f, 4f));

        // rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, xMin, xMax), Mathf.Clamp(rBody.position.y, yMin, yMax));
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));
        if (Math.Abs(rBody.velocity.x) > Math.Abs(rBody.velocity.y))
        {
            GetComponent<Animator>().SetFloat("DirX", rBody.velocity.x);
            GetComponent<Animator>().SetFloat("DirY", 0);
        }
        else
        {
            GetComponent<Animator>().SetFloat("DirY", rBody.velocity.y);
            GetComponent<Animator>().SetFloat("DirX", 0);
        }
    }
    

}
