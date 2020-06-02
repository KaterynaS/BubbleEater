using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    fish fishScript;

    public GameObject bubbleBurst;
    int fishNum;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        fishScript = GameObject.FindGameObjectWithTag("fish").GetComponent<fish>();
        string a = GameObject.FindGameObjectWithTag("fishNumberText").GetComponentInChildren<TMP_Text>().text.ToString();
        fishNum = int.Parse(a);
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

            //Debug.Log("should merge");
            int a = int.Parse(collision.GetComponentInChildren<TextMeshPro>().text.ToString());
            int b = int.Parse(gameObject.GetComponentInChildren<TextMeshPro>().text.ToString());

            int summ = a + b;

            string newNum = "" + summ;


            if (summ == fishNum)
            {
                rightBubblePrefab.GetComponentInChildren<TextMeshPro>().SetText(newNum);
                Instantiate(rightBubblePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                bubblePrefab.GetComponentInChildren<TextMeshPro>().SetText(newNum);
                Instantiate(bubblePrefab, transform.position, Quaternion.identity);
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
