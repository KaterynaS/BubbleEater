using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaWeedWaving : MonoBehaviour
{

    private int rotationSpeed = 5;

    private float rotationDuration;
    private float startTimeBtwRandomMoves = 3;

    private bool rotateForeward = true;
    private bool isFirstRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("rotationSpeed = " + rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (isFirstRotation)
        {

            //Debug.Log("isFirstRotation = " + isFirstRotation);
            if (rotationDuration >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 10);
                //transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                rotationDuration -= Time.deltaTime;
            }
            else
            {
                isFirstRotation = false;
            }
        }
        else
        {

            //Debug.Log("isFirstRotation = " + isFirstRotation);
            if (rotationDuration >= 0)
            {
                if (rotateForeward)
                {
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                }
                rotationDuration -= Time.deltaTime;

            }
            else
            {
                //change rotateForeward
                rotateForeward = !rotateForeward;
                rotationDuration = startTimeBtwRandomMoves;
            }
        }
    }
}
