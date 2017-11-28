using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public Animator anim;
    public Text WinText;
    public GameObject camera1;
    public GameObject scoreControl;
    public GameObject FinalPanel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colli) {
        if (colli.gameObject.tag == "Player") {
            anim.SetBool("WinArea", true);
            colli.gameObject.GetComponent<DemoScene>().enabled = false;
            WinText.gameObject.SetActive(true);
            scoreControl.GetComponent<ChangeLevelContent>().SetScore(camera1.GetComponent<ScoreCounter>()._text.text, 1);
            FinalPanel.SetActive(true);
        }
    }
}
