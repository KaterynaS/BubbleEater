using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    private TextMeshProUGUI numberOnBubble;
    private TextMeshProUGUI numberOnTergetBubble;

    public Transform[] spawnPoints;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject bubblePrefab;

    private bool isGameGoing = true;

    GameState gameState;
    private int[] bubbleNumbers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawner, Start " + "active");
        gameState = GameState.GetInstance();

        //get LevelBubbles and form an array of ints to choose from

        int currentLvl = gameState.getCurrentLevel();
        Debug.Log("Spawner, Start " + "CurrentLevel: " + currentLvl);
        Level currentLevel = LevelsDescription.getLevelDescription(currentLvl);

        LevelBubble[] levelBubbles = currentLevel.getLevelBubbles();

        int arrayOfBubbleNumbersLength = 0;
        for (int i = 0; i < levelBubbles.Length; i++)
        {
            arrayOfBubbleNumbersLength = arrayOfBubbleNumbersLength + levelBubbles[i].getBubbleProbability();
        }

        bubbleNumbers = new int[arrayOfBubbleNumbersLength];

        int counter = 0;
        Debug.Log("Spawnr: counter 0");

        for (int z = 0; z < levelBubbles.Length; z++)
        {
            for (int k = 0; k < levelBubbles[z].getBubbleProbability(); k++)
            {
                Debug.Log("Spawnr: add " + k + " bubbles with number " + levelBubbles[z].getBubbleNumber() + "to array" );
                bubbleNumbers[counter] = levelBubbles[z].getBubbleNumber();
                counter++;
            }
        }


        for (int t = 0; t < bubbleNumbers.Length; t++)
        {
            int tmp = bubbleNumbers[t];
            int r = Random.Range(t, bubbleNumbers.Length);
            bubbleNumbers[t] = bubbleNumbers[r];
            bubbleNumbers[r] = tmp;
        }

        string bubbleNumbersString = "";
        for (int k = 0; k < bubbleNumbers.Length; k++) { bubbleNumbersString = bubbleNumbersString + bubbleNumbers[k]; }

        Debug.Log("Spawner: randomizedBubbleNombres: " + bubbleNumbersString);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameGoing)
        {
            if (timeBtwSpawns <= 0)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                //todo float bubbleRadius;
                string textOnBubbleString;

                //get random from levelBubbles array

                int randIndexFromLevelBubblesArray = Random.Range(0, bubbleNumbers.Length);
                Debug.Log("Spawner, Update " + "levelBubbles.Length = " + bubbleNumbers.Length);
                Debug.Log("Spawner, Update " + "randIndexFromLevelBubblesArray = " + randIndexFromLevelBubblesArray);
                textOnBubbleString = "" + bubbleNumbers[randIndexFromLevelBubblesArray];

                string bubbleNumbersString = "";
                for (int k = 0; k < bubbleNumbers.Length; k++) { bubbleNumbersString = bubbleNumbersString + bubbleNumbers[k]; }

                Debug.Log("Spawner: Update bubbleNumbers: " + bubbleNumbersString + " print: " + textOnBubbleString);

                //bubblePrefab.GetComponentInChildren<TextMeshProUGUI>().SetText(textOnBubbleString);
                bubblePrefab.GetComponentInChildren<Text>().text = textOnBubbleString;

                //numberOnBubble.SetText(textOnBubbleString);
                Instantiate(bubblePrefab, randomSpawnPoint.position, Quaternion.identity);

                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }


    public void setIsGameGoing(bool isGoing)
    {
        isGameGoing = isGoing;
    }
}