using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 for the item that can be hit, the layer must be set to "item layer"
 every different unity project's layer settings are different
 the item layer must be set at the first tie before this script is used
 */
public class GetItem : MonoBehaviour {
    public int Layer_Player;
    public int Layer_Item;
    public int Layer_platform;
    public Texture[] images = new Texture[4];
    public RawImage targetimage;
    public GameObject create_location;
    public GameObject ball_created;
    bool isBallExist = false;
    float t = 0;
    public GameObject thisBall;
    float ball_basetime=3;
    GameObject ProblemLoading;

    void Start () {

    }
	
	
	void Update ()
    {
        if(isBallExist==true)
        {
            t += Time.deltaTime;
        }
        if(t>3)
        {
            Destroy(thisBall);
            isBallExist = false;
            t = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layer_Item)
        {
            switch (collision.gameObject.tag) {
                case "basketball_item":
                    Destroy(collision.gameObject);
                    GameObject.Find("ScoreControl").GetComponent<scorecontrol>().AdjustScore(-5);
                    if(!isBallExist)
                    {
                        thisBall=Instantiate(ball_created, create_location.transform.position, ball_created.transform.rotation);
                        thisBall.GetComponent<Rigidbody2D>().velocity = new Vector3(20f, 30f, 0f);
                        isBallExist = true;
                    }
                    else
                    {
                        t -= ball_basetime;
                    }    
                    break;
                case "bike":
                    GameObject.Find("ScoreControl").GetComponent<scorecontrol>().AdjustScore(-5);
                    break;
                case "Chalk":
                    Destroy(collision.gameObject);
                    break;
                case "basketball":
                    break;
                case "Problem":
                    Destroy(collision.gameObject);
                    this.GetComponent<DemoScene>().enabled = false;

                    //Time.timeScale = 0;
                    GameObject.Find("ProblemLoading").GetComponent<problemLoading>().ShowProblem();
                    GameObject.Find("basketball_working(Clone)").GetComponent<Rigidbody>().mass = 0.0f;
                   // Time.timeScale = 1;
                    break;
            }
        }
        if(collision.gameObject.layer==9)
        {
            if(collision.gameObject.tag=="basketball")
            {
                //print("!!!");
            }
        }
        
    }
}
