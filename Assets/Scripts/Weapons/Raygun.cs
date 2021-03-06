﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raygun : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject firePoint;
    public GameObject bullet_1_prefab;
    private float cooldown_left;
    private float shooting_repeat_rate;
    private float cooldown;


    void Start()
    {
        firePoint = GameObject.Find("FirePoint");
        cooldown = PlayerPrefs.GetFloat("raygun_cooldown", 10.0f);
        shooting_repeat_rate = PlayerPrefs.GetFloat("raygun_shooting_repeat_rate", 1.0f);
    }


    void FixedUpdate()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -GameScript.instance.gameSpeed + 0.5f);
        if (transform.position.y < -7.5f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.SetActive(false);
            Start_Raygun();
        }
    }

    void Start_Raygun()
    {
        cooldown_left += cooldown;
        InvokeRepeating("Raygun_shoot", 0, shooting_repeat_rate);
        InvokeRepeating("Check_Game_Over", 0, 0.25f);
    }

    private void Raygun_shoot()
    {
        /* Spawn Bullet */
        Instantiate(bullet_1_prefab, firePoint.transform.position, firePoint.transform.rotation);
        cooldown_left -= shooting_repeat_rate;
        /* When cooldown is over stop loop */
        if (cooldown_left <= 0)
        {
            CancelInvokes();
        }
    }

    /* Fix so Raygun doesnt shoot next game if you restart too fast */
    private void Check_Game_Over()
    {
        if (!GameScript.instance.game_running)
        {
            CancelInvokes();
        }
    }

    private void CancelInvokes()
    {
        CancelInvoke("Raygun_shoot");
        CancelInvoke("Check_Game_Over");
    }
}
