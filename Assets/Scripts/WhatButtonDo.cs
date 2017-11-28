using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhatButtonDo : MonoBehaviour {
    public GameObject loadScreen = null;
    public Text loadText = null;
    public Image loadImage = null;

    public GameObject SettingPanel = null;

    public void ChangeSceneToChoosingLevel() {
        if (loadScreen != null)
        {
            loadScreen.transform.localScale = new Vector3(1, 1, 1);
            print(loadScreen.activeSelf);
            CloseTheSettingWindow();
            StartCoroutine(DisplayLoadingScreen("Choosing"));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenTheSettingWindow()
    {
        Time.timeScale = 0;
        if (SettingPanel != null) {
            SettingPanel.SetActive(true);
        }
    }
    public void RestartGame() {
        //restart function
        CloseTheSettingWindow();
        ChangeSceneToPlayGame();
    }
    public void CloseTheSettingWindow()
    {
        Time.timeScale = 1;
        if (SettingPanel != null)
        {
            SettingPanel.SetActive(false);
        }
    }

    public void ChangeSceneToOpening() {
        if (loadScreen != null)
        {
            loadScreen.transform.localScale = new Vector3(1, 1, 1);
            CloseTheSettingWindow();
            StartCoroutine(DisplayLoadingScreen("Opening"));
        }
    }

    public void ChangeSceneToPlayGame()
    {
        if (loadScreen != null)
        {
            loadScreen.transform.localScale = new Vector3(1, 1, 1);
            CloseTheSettingWindow();
            StartCoroutine(DisplayLoadingScreen("test"));
        }
    }

    IEnumerator DisplayLoadingScreen(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            if (loadText != null)
            {
                loadText.text = (async.progress * 100).ToString() + "%";
            }
            if (loadImage != null)
            {
                loadImage.transform.localScale = new Vector2(async.progress, loadImage.transform.localScale.y);
                print(loadImage.transform.localScale);
            }
            yield return null;
        }
    }
}
