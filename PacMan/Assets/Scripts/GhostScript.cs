using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    
    public Transform[] waypoints;
    public GameObject player;
    public float speed;
    private int currentPoint = 0;
    private Rigidbody2D rbody;
    private Animator anim;
    private bool isScared;
    // Use this for initialization
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!anim.GetBool("Scared"))
        { 
        if (Vector2.Distance(this.transform.position, waypoints[currentPoint].position) != 0)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[currentPoint].position, speed);
            rbody.MovePosition(p);


        }
        else
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
            Debug.Log("h");
        }


        Vector2 dir = waypoints[currentPoint].position - this.transform.position;
        anim.SetFloat("DirX", dir.x);
        anim.SetFloat("DirY", dir.y);
        
        }
        else if (anim.GetBool("Scared"))
        {
            if (Vector2.Distance(player.transform.position, waypoints[currentPoint].position) < Vector2.Distance(player.transform.position, waypoints[currentPoint - 1].position))
            {
                Vector2 p = Vector2.MoveTowards(transform.position, waypoints[currentPoint - 1].position, speed);
                rbody.MovePosition(p);

                if (Vector2.Distance(transform.position, waypoints[currentPoint-1].position) == 0)
                    {
                    Debug.Log(currentPoint);
                    currentPoint = currentPoint - 1 % waypoints.Length;
                }
            }
            else
            {
                Vector2 p = Vector2.MoveTowards(transform.position, waypoints[currentPoint].position, speed);
                rbody.MovePosition(p);
                if (Vector2.Distance(transform.position, waypoints[currentPoint].position) == 0)
                {
                    Debug.Log(currentPoint);
                    currentPoint = currentPoint + 1 % waypoints.Length;
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !anim.GetBool("Scared"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player") && anim.GetBool("Scared"))
        {
            Destroy(this.gameObject);
        }

    }
    
}
