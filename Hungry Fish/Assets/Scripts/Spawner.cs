using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject bubblePrefab;

    private int minNumberOnBubble;
    private int maxNumberOnBubble;
    private int numberOnBubble;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            //todo float bubbleRadius;


            string textOnBubbleString = Random.Range(minNumberOnBubble, maxNumberOnBubble) + "";

            bubblePrefab.GetComponentInChildren<TextMeshPro>().SetText(textOnBubbleString);

            Instantiate(bubblePrefab, randomSpawnPoint.position, Quaternion.identity);

            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }



    public void setMinNumberOnBubble(int minBubbleNumber)
    {
        minNumberOnBubble = minBubbleNumber;
    }


    public void setMaxNumberOnBubble(int maxBubbleNumber)
    {
        maxNumberOnBubble = maxBubbleNumber;
    }


}
