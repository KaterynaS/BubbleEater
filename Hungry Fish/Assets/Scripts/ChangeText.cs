using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    int[] k;

    private float timeBtwSpawns = 2;
    public float startTimeBtwSpawns = 2;

    // Start is called before the first frame update
    void Start()
    {
        k = new int[]{1,2,3,4 };
        //numberOnBubble.SetText(textOnBubbleString);
        //Instantiate(bubblePrefab, randomSpawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {



        if (timeBtwSpawns <= 0)
        {
            string text = k[Random.Range(0, k.Length)].ToString() + "";
            gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
