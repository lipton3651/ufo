﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed;
    private int add_score;
    void Update()
    {
        MoveBackground();
        MoveBackBackground();
        AddScore();
    }

    void MoveBackground()
    {
        if (GameScript.instance.game_running)
        {
            speed = (GameScript.instance.gameSpeed * Time.deltaTime) * 1.5f;
            transform.Translate(0, -speed, 0);
        }
        else
        {
            transform.Translate(0, -0.1f, 0);
        }
    }

    void MoveBackBackground()
    {
        if (transform.position.y <= -43.50f)
        {
            transform.Translate(0, 43.50f * 2, 0);
        }
    }

    void AddScore()
    {
        if (GameScript.instance.game_running)
        {
            add_score = Mathf.RoundToInt(speed * 10);
            if (add_score < 1)
            {
                Score.instance.AddScore(1);
            }
            Score.instance.AddScore(add_score);
        }
    }

}