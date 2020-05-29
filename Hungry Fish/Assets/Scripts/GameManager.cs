using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("open game");
    }

}
