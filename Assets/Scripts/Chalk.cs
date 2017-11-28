using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * 180.0f));
        this.transform.Translate(new Vector3(-Time.deltaTime * 10.0f, 0.0f, 0.0f), Space.World);
    }
}
