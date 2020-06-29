using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bubbles : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float speed;

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    public GameObject rightBubblePrefab;
    public GameObject bubblePrefab;

    private fish fishScript;

    public GameObject bubbleBurst;
    int fishNum;

    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.GetInstance();
        speed = Random.Range(minSpeed, maxSpeed);
        fishScript = GameObject.FindGameObjectWithTag("fish").GetComponent<fish>();
        //string a = GameObject.FindGameObjectWithTag("fishNumberText").GetComponentInChildren<TMP_Text>().text.ToString();
        //fishNum = int.Parse(a);

        Level currentLevel = LevelsDescription.getLevelDescription(gameState.getCurrentLevel());
        fishNum = currentLevel.getFishTargetNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }

        else
        {
            Debug.Log("bubbles, Update " + "move up");
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "surface")
        {
            Destroy(gameObject);
        }


        if (collision.tag == "fish" && gameObject.tag == "rightBubble")
        {
            Destroy(gameObject);
            fishScript.eat();
            fishScript.setIsThereFood(false);
            
            Instantiate(bubbleBurst, collision.transform.position, Quaternion.identity);
        }

        

        if (collision.tag == "bubble" && isBeingHeld == true && gameObject.tag == "bubble")
        {
            Debug.Log("bubbles, OnTriggerEnter2D " + "collision.tag = " + collision.tag + " gameObject.tag = " + gameObject.tag);
            //int a = int.Parse(collision.GetComponentInChildren<TextMeshProUGUI>().text.ToString());
            //int b = int.Parse(gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToString());

            int a = int.Parse(collision.GetComponentInChildren<Text>().text.ToString());
            int b = int.Parse(gameObject.GetComponentInChildren<Text>().text.ToString());

            int summ = a + b;

            string newNum = "" + summ;

            if (summ == fishNum)
            {
                rightBubblePrefab.GetComponentInChildren<Text>().text = newNum;
                Instantiate(rightBubblePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                if (summ > fishNum)
                {
                    Instantiate(bubbleBurst, collision.transform.position, Quaternion.identity);
                }
                else
                {
                    bubblePrefab.GetComponentInChildren<Text>().text = newNum;
                    Instantiate(bubblePrefab, transform.position, Quaternion.identity);
                }
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

}
