using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scorecontrol : MonoBehaviour {
    public Text scoretext;
    float score = 60.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoretext.text = ((int)score).ToString();
        //score += Time.deltaTime * 5;
	}

    public void AdjustScore(int num) {
        score += num;
        if (score < 0)
            score = 0;
        else if (score > 100)
            score = 100;
        scoretext.text = score.ToString();
    }
}
