using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIButtons : MonoBehaviour
{
    GameState gameState;
    public GameObject backButton;
    public GameObject infoButton;
    public GameObject mapButton;


    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public SpriteState soundButtonSpriteState;
    public AudioMixer audioMixer;


    void Start()
    {
        soundButtonSpriteState = new SpriteState();
        soundButtonSpriteState = soundButton.spriteState;

        gameState = GameState.GetInstance();

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("UIButtons: " + " active scene: " + scene.name.ToString());

        if(scene.name == "Main")
        {
            infoButton.SetActive(true);

            backButton.SetActive(false);
            mapButton.SetActive(false);
        }

        if (scene.name == "Info")
        {
            backButton.SetActive(true);

            infoButton.SetActive(false);
            mapButton.SetActive(false);
        }

        if (scene.name == "Game")
        {
            mapButton.SetActive(true);

            backButton.SetActive(false);
            infoButton.SetActive(false);
        }

        if (scene.name == "Map")
        {
            infoButton.SetActive(true);
            backButton.SetActive(false);
            mapButton.SetActive(false);
        }
    }

    public void turnSound()
    {
        if (soundButton.image.sprite == soundOnSprite)
        {
            gameState.turnSoundOff();
            soundButton.image.sprite = soundOffSprite;
            audioMixer.SetFloat("Volume", -80);
        }
        else
        {
            gameState.turnSoundOn();
            soundButton.image.sprite = soundOnSprite;
            audioMixer.SetFloat("Volume", 0);
        }
    }

    public void goBack()
    {
        Debug.Log("UIButtons: " + "goBack");
        Debug.Log("UIButtons, goBack " + "previousScene: " + gameState.getPreviousScene());

        if (gameState.getPreviousScene() == "Main") {SceneManager.LoadScene("Main"); }
        else if (gameState.getPreviousScene() == "Map") { SceneManager.LoadScene("Map"); }
    }

    public void openMain()
    {
        SceneManager.LoadScene("Main");
    }


    public void openInfo()
    {
        Scene scene = SceneManager.GetActiveScene();
        gameState.setPreviousScene(scene.name.ToString());
        SceneManager.LoadScene("Info");
        Debug.Log("UIButtons, openInfo " + "previousScene: " + scene.name.ToString());
    }

    public void openMap()
    {
        SceneManager.LoadScene("Map");
    }
}
