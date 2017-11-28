using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class problemLoading : MonoBehaviour {
    string[] ProblemSet;
    int[] Existed;
    public GameObject ProblemWindow;
    public Text expression;
    public Text[] choices = new Text[4];
    int nowAnswer;
    float waitTime = 0.5f;
    // Use this for initialization
    void Start () {
        //Debug.Log(System.IO.Path.GetFullPath(".\\我想畢業_Data\\Problems.txt"));
        ProblemSet = FileLoading(@".\我想畢業_Data\Problems.txt");
        //ProblemSet = FileLoading(@"C:\Users\Lenovo\Desktop\我想畢業_Data\Problems.txt");
        Debug.Log(ProblemSet.Length);
        Existed = new int[3];
        for (int i = 0; i < Existed.Length; i++) {
            Existed[i] = 0;
        }
        
	}

    string[] FileLoading(string filename)
    {
        return System.IO.File.ReadAllLines(filename);
    }

    public void ShowProblem()
    {
        Debug.Log("123");
        for (int i = 0; i < Existed.Length; i++) {
            Debug.Log(Existed[i]);
        }
        for(int i = 0; i < 3;i++)
        {
            int ProblemIndex = Random.Range(0,3);
            
            if (Existed[ProblemIndex] == 0)
            {
                Debug.Log(ProblemIndex);
                Existed[ProblemIndex] = 1;
                ProblemWindow.SetActive(true);
                nowAnswer = int.Parse(ProblemSet[ProblemIndex * 7 + 1]);
                expression.text = ProblemSet[ProblemIndex * 7 + 2];
                choices[0].text = ProblemSet[ProblemIndex * 7 + 3];
                choices[1].text = ProblemSet[ProblemIndex * 7 + 4];
                choices[2].text = ProblemSet[ProblemIndex * 7 + 5];
                choices[3].text = ProblemSet[ProblemIndex * 7 + 6];
                break;
            }
        }
    }

    public void IsCorrect(int choice) {
        if (choice == nowAnswer)
        {
            expression.text = "恭喜答對!!!!";
            GameObject.Find("ScoreControl").GetComponent<scorecontrol>().AdjustScore(10);
        }
        else
        {
            expression.text = "答錯囉~~~";
            GameObject.Find("ScoreControl").GetComponent<scorecontrol>().AdjustScore(-5);
        }
        InvokeRepeating("countdown", 0.5f, 1);
    }

    void countdown() {
        waitTime -= 0.5f;
        Debug.Log(waitTime);
        if (waitTime == 0) {
            waitTime = 0.5f;
            ProblemWindow.SetActive(false);
            GameObject.Find("character").GetComponent<DemoScene>().enabled = true;
            GameObject.Find("basketball_working(Clone)").GetComponent<Rigidbody>().mass = 1.0f;
            CancelInvoke("countdown");
        }
    }
}
