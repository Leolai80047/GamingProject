using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelContent {
    private string levelName;
    private string hightestScore;
    public LevelContent() {
        levelName = "";
        hightestScore = "";
    }
    public string GetLevelName() { return levelName; }
    public void SetLevelName(string name) { levelName = name; }
    public string GetScore() { return hightestScore; }
    public void SetHighestScore(string score) { hightestScore = score; }
}
public class ChangeLevelContent : MonoBehaviour {
    string[] allClassName = { "數學", "國文", "程式語言" };
    string[] AllLevelContent;
    LevelContent[] organizedData;
    public Text LevelName;
    public Text HighestScore;
    public Button[] allButtons = new Button[3];
	// Use this for initialization
	void Start () {
        AllLevelContent = FileLoading(@".\我想畢業_Data\LevelContent.txt");
        organizedData = DataOrganization(AllLevelContent);
        GetNewLevelContent();
    }

    string[] FileLoading(string filename)
    {
        return System.IO.File.ReadAllLines(filename);
    }

    LevelContent[] DataOrganization(string[] data) {
        int sizeofData = 2;
        int NumberOfLevel = data.Length / sizeofData;
        LevelContent[] OrganizedData = new LevelContent[NumberOfLevel];
        for (int i = 0; i < NumberOfLevel; i++) {
            OrganizedData[i] = new LevelContent();
            OrganizedData[i].SetLevelName(data[i * 2]);
            OrganizedData[i].SetHighestScore(data[i * 2 + 1]);
        }
        return OrganizedData;
    }
    public void GetLevelContent(string levelname) {
        for (int i = 0; i < organizedData.Length; i++) {
            if (levelname == organizedData[i].GetLevelName()) {
                if (organizedData[i].GetScore() != "NULL")
                {
                    HighestScore.text = organizedData[i].GetScore();
                }
                else {
                    HighestScore.text = "";
                }
                LevelName.text = allClassName[i];
                break;
            }
        }
    }

    public void GetNewLevelContent() {
        for (int i = 0; i < organizedData.Length; i++) {
            if (organizedData[i].GetScore() == "NULL")
            {
                LevelName.text = allClassName[i];
                HighestScore.text = "";
                allButtons[i].interactable = true;
                break;
            }
            else {
                allButtons[i].interactable = true;
            }
            if (i + 1 == organizedData.Length) {
                LevelName.text = allClassName[i];
                HighestScore.text = organizedData[i].GetScore();
                break;
            }
        }
    }

    public void SetScore(string newScore, int levelIndex) {
        for (int i = 0; i < AllLevelContent.Length; i++)
        {
            Debug.Log(AllLevelContent[i]);
        }
        AllLevelContent[(levelIndex - 1) * 2 + 1] = newScore;
        for (int i = 0; i < AllLevelContent.Length; i++)
        {
            Debug.Log(AllLevelContent[i]);
        }
        System.IO.File.WriteAllLines(@".\我想畢業_Data\LevelContent.txt", AllLevelContent);
    }
}
