using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameState gameState;

    void Start()
    {
        gameState = GameState.GetInstance();
    }

    public void openLevelMap()
    {
        SceneManager.LoadScene("Map");
        Debug.Log("GameManager: " + "open level map");
    }


    public void playLevelOne()
    {
        Debug.Log("GameManager: " + "open level 1");
        gameState.setCurrentLevel(0);
        SceneManager.LoadScene("Game");
    }

    public void playLevelTwo()
    {
        Debug.Log("GameManager: " + "open level 2");
        gameState.setCurrentLevel(1);
        SceneManager.LoadScene("Game");
    }

    public void playLevelThree()
    {
        Debug.Log("GameManager: " + "open level 3");
        gameState.setCurrentLevel(2);
        SceneManager.LoadScene("Game");
    }

    public void playLevelFour()
    {
        Debug.Log("GameManager: " + "open level 4");
        gameState.setCurrentLevel(3);
        SceneManager.LoadScene("Game");
    }

}
