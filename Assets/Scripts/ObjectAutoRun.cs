using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAutoRun : MonoBehaviour {
    /*
     this script must be in the gama object that want to move automacily
     */
    public float speed = 10;
    public bool running = true;
    Animator anim;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (running)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.right*speed;
        }	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Win")
        {
            this.GetComponent<Animator>().SetBool("WinArea", true);
            running = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        print("123");
    }
}
