using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWall : MonoBehaviour {
    
    public GameObject ball;
    
	void Start () {

    }
	
	void Update () {
        ball = GameObject.Find("character").GetComponent<GetItem>().thisBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "basketball")
        {
            Vector2 temp = ball.GetComponent<Rigidbody2D>().velocity;
            switch (this.gameObject.name)
            {
                case "Cube":
                    temp = new Vector2(25.0f, temp.y);
                    //temp.x = 30f;
                    break;
                case "Cube (1)":
                    temp = new Vector2(-25.0f,temp.y);
                    //temp.x = -30f;
                    break;
                case "Cube (2)":
                    temp = new Vector2(temp.x, -15);
                    //temp.y = -40;
                    break;
                case "Cube (3)":
                    temp = new Vector2(temp.x, 15);
                    //temp.y = 40;
                    break;
            }
        ball.GetComponent<Rigidbody2D>().velocity = temp;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chalk")
            Destroy(collision.gameObject, 3.0f);
    }
}
