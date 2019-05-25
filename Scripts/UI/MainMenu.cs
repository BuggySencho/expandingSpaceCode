﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("lovingSpace");
    }
	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}
}
