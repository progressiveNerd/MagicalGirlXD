﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss : Entity
{
    public int currentHealth;
    public int startingHealth;
    public int damage;
    public Transform shotPrefab;
    public BossAttack attackscript;
    bool baseReached = false;
    bool attacked = false;
    bool waited = false;
    int phase = 0;
    bool cutsceneEnd = false;
    bool click = false;
    public int counter;
    public BossLoad bossssss;
    public Camera mainCam;
    public CameraFollow yep;
    Animator anim;

    public GameObject bossMan;
    public GameObject player;
    public Player playerScript;

    public GameObject gymText;
    public GameObject studentText;
    public Text textbox;
    public GameObject canv;
    public Slider health;
    public GameObject levelComplete;

    float speed;
    //Home - 23, 33
    //Second - 23, 16
    //First - 15,25
    //Third - 30, 25
    private Vector2 firstBase = new Vector2(15, 25);
    private Vector2 secondBase = new Vector2(23, 16);
    private Vector2 thirdBase = new Vector2(30, 25);
    private Vector2 homeBase = new Vector2(23, 33);
    Vector3 movement;

    Rigidbody2D bossRigidBody;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        bossRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        counter = 0;
        phase = 1;
        speed = 7.0f;
        currentHealth = startingHealth;
        Cutscene();
    }

    void Update()
    {
        if (!cutsceneEnd)
            Cutscene();
        else if (cutsceneEnd && phase == 1)
            MovePhase();
        else if (phase == 2)
            MovePhase();
        else if (phase == 3)
            MovePhase();
        else if (phase == 4)
            MovePhase();
    }

    void Move(float h, float v, float speed)
    {
        movement.Set(h, v, 0f);
        movement = movement.normalized * speed * Time.deltaTime;
        bossRigidBody.MovePosition(this.gameObject.transform.position + movement);
    }

    void MovePhase()
    {
        if (phase == 2)
        {
            if (transform.position.x < 23 && transform.position.y > 16 && baseReached != true)
                Move(secondBase.x - transform.position.x, secondBase.y - transform.position.y, speed);
            else
            {
                baseReached = true;
                if (!waited)
                    waitPhase();
            }
        }

        else if (phase == 3)
        {
            if (transform.position.x < 30 && transform.position.y < 25 && baseReached != true)
                Move(thirdBase.x - transform.position.x, thirdBase.y - transform.position.y, speed);
            else
            {
                baseReached = true;
                if (!waited)
                    waitPhase();
            }
        }

        else if (phase == 4)
        {
            if (transform.position.x > 23 && transform.position.y < 33 && baseReached != true)
                Move(homeBase.x - transform.position.x, homeBase.y - transform.position.y, speed);
            else
            {
                baseReached = true;
                if (!waited)
                    waitPhase();
            }
        }

        else if (phase == 1)
        {
            if (transform.position.x > 15 && transform.position.y > 25 && baseReached != true)
                Move(firstBase.x - transform.position.x, firstBase.y - transform.position.y, speed);
            else
            {
                baseReached = true;
                if (!waited)
                    waitPhase();
            }
        }
    }

    void AttackPhase()
    {
        if (phase == 1 && !attacked)
        {
            anim.SetTrigger("Attack");
            attackscript.Attack(player);
            phase++;
        }
        else if (phase == 2 && !attacked)
        {
            anim.SetTrigger("Attack");
            attackscript.Attack(player);
            phase++;
        }
        else if (phase == 3 && !attacked)
        {
            anim.SetTrigger("Attack");
            attackscript.Attack(player);
            phase++;
        }
        else if (phase == 4 && !attacked)
        {
            anim.SetTrigger("Attack");
            attackscript.Attack(player);
            playerScript.TakeDamage(5);
        }
        baseReached = false;
        attacked = true;
        waited = false;
    }

    public void Cutscene()
    {
        if (counter == 0)
            gymText.SetActive(true);
        playerScript.enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
        if (Input.GetKeyDown("enter") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (counter == 0)
            {
                counter++;
                gymText.SetActive(false);
                studentText.SetActive(true);
                yep.ChangePosition(new Vector3(23.0f, 25.0f, -10.0f));
            }
            else if (counter == 1)
            {
                counter++;
                textbox.text = "Don't let him hit a homerun!!";
            }
            else if (counter == 2)
            {
                canv.SetActive(false);
                studentText.SetActive(false);
                playerScript.enabled = true;
                player.GetComponent<PlayerAttack>().enabled = true;
                cutsceneEnd = true;
            }
        }
    }

    protected override void Death()
    {
        this.GetComponent<Boss>().enabled = false;
        levelComplete.SetActive(true);
        playerScript.enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
    }

    public override void TakeDamage(int amount)
    {
        if (!baseReached)
            currentHealth--;
        health.value = currentHealth;
        if (currentHealth <= 0)
            Death();
    }

    public void waitPhase()
    {
        waited = true;
        Invoke("AttackPhase", 1.0f);
        attacked = false;
    }
}