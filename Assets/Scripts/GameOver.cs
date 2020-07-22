﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restartGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void goToMainMenu()  {
        SceneManager.LoadScene("MainMenu");
    }
}