using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameState gameState;
    private static MusicManager instance;

    private void Awake()
    {
        gameState = GameState.GetInstance();
        gameState.turnSoundOn();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
