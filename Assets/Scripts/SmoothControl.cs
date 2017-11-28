using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothControl : MonoBehaviour {
    public Transform Object2Follow;
    public float radius;
    public float Smooth;
    public float ysmooth;
    private Vector2 smoothposition = Vector2.zero;
	// Use this for initialization
	void Start () {
        if (!Object2Follow)
        {
            this.enabled = false;
        }
        else
        {
            this.transform.parent = null;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.x > Object2Follow.position.x + radius || this.transform.position.x < Object2Follow.position.x + radius) 
        {
            //    this.transform.position = Vector2.Lerp(this.transform.position, Object2Follow.position, Smooth * Time.deltaTime);
            smoothposition.x = Mathf.Lerp(this.transform.position.x, Object2Follow.transform.position.x, Smooth * Time.deltaTime);
            smoothposition.y = this.transform.position.y;
            this.transform.position = smoothposition;

        }
    }
    bool CheckMargin()
    {
        return Vector2.Distance(this.transform.position, Object2Follow.position) > radius;
    }
}
