﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class fish : MonoBehaviour
{
    public float speedToTarget = 1.8f;
    public float speedIdle = 0.8f;

    private Transform target;

    private float xDiff;
    private float yDiff;

    private bool isThereFood;

    private int fishNumber;

    private float timeBtwRandomMoves;
    public float startTimeBtwRandomMoves;

    Vector3 pointB = new Vector3(15, 15, 0);

    private int currentLevel;
    private int bubblesEatenOnCurrentLevel = 0;
    private int bubblesPerCurrentLevel = 10;

    public LevelProgressIndicator levelProgressBar;

    Animator animator;

    public GameObject WinPanel;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        levelProgressBar.setBubblesPerCurrentLevel(bubblesPerCurrentLevel);

        //Debug.Log("Start: progress");

        setFishNumber(fishNumber);
    }


    public void setFishNumber(int number)
    {
        string a = GameObject.FindGameObjectWithTag("fishNumberText").GetComponentInChildren<TMP_Text>().text.ToString();

        //Debug.Log("Start: fish number text: " + a);

        string fn = "" + number;
        GameObject.FindGameObjectWithTag("fishNumberText").GetComponentInChildren<TMP_Text>().SetText(fn);
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("rightBubble").Length > 0)
        {
            GameObject a = GameObject.FindGameObjectWithTag("rightBubble");
            target = a.GetComponent<Transform>();

            //Debug.Log("target move, position: " + target.position.ToString());

            transform.position = Vector2.MoveTowards(transform.position,
                target.position,
                speedToTarget * Time.deltaTime);

            animator.SetBool("isEating", false);
            animator.SetBool("isMoving", true);
            animator.SetBool("isIdle", false);

            xDiff = transform.position.x - target.position.x;


            if (xDiff > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //GameObject.FindGameObjectWithTag("fishNumberText").transform.eulerAngles = new Vector3(0, 0, 0);


            }
            else if (xDiff < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                //GameObject.FindGameObjectWithTag("fishNumberText").transform.eulerAngles = new Vector3(0, 0, 0);

            }
        }

        else
        {

            animator.SetBool("isEating", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isIdle", true);
            //Debug.Log("random move");

            if (timeBtwRandomMoves >= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    pointB,
                    speedIdle * Time.deltaTime);

                xDiff = transform.position.x - pointB.x;

                if (xDiff > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    //GameObject.FindGameObjectWithTag("fishNumberText").transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (xDiff < 0)
                {
                    gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                    //GameObject.FindGameObjectWithTag("fishNumberText").transform.eulerAngles = new Vector3(0, 0, 0);
                }

                timeBtwRandomMoves -= Time.deltaTime;

            }
            else
            {
                timeBtwRandomMoves = startTimeBtwRandomMoves;
                pointB = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
            }
        }
    }


    public void setIsThereFood(bool a)
    {
        isThereFood = a;
    }


    public void eat()
    {

        animator.SetBool("isEating", true);
        animator.SetBool("isMoving", false);
        animator.SetBool("isIdle", false);
        timeBtwRandomMoves = startTimeBtwRandomMoves;
        //todo eat animation
        bubblesEatenOnCurrentLevel++;



        levelProgressBar.setBubblesEatenSlider(bubblesEatenOnCurrentLevel);


        Debug.Log("bubblesEatenOnCurrentLevel = " + bubblesEatenOnCurrentLevel + " from " + bubblesPerCurrentLevel);

        if (bubblesEatenOnCurrentLevel >= bubblesPerCurrentLevel)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        //todo
        //currentLvl++;
        //change bubblesPerCurrentLevel
        //change bubbles varaety
        //


        //greeting actions
        //go to next lvl or lvl select?

        WinPanel.SetActive(true);

    }


}

class ArrayList<T>
{
}