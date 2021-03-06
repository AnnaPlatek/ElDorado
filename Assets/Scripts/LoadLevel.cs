﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex==0 || currentSceneIndex==1)
        {
            StartCoroutine(WaitForTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadPlayerStats()
    {
        SceneManager.LoadScene("PlayerStats");
    }

    public void LoadHelpsOptions()
    {
        SceneManager.LoadScene("HelpsOptions");
    }


}
