using System.Collections;
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
    private int bubblesPerCurrentLevel = 3;

    public LevelProgressIndicator levelProgressBar;

    Animator animator;

    public GameObject WinPanel;

    AudioSource audioSource;

    GameState gameState;

    void Start()
    {
        gameState = GameState.GetInstance();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        levelProgressBar.setBubblesPerCurrentLevel(bubblesPerCurrentLevel);
    }


    public void setFishNumber(int number)
    {
        string a = GameObject.FindGameObjectWithTag("fishNumberText").GetComponentInChildren<TMP_Text>().text.ToString();

        Debug.Log("fish " + "setFishNumber: " + number);

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
            }
            else if (xDiff < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
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
        if (gameState.isSoundOn()) {audioSource.Play(); }
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
        WinPanel.SetActive(true);

        Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        spawner.setIsGameGoing(false);
    }
}