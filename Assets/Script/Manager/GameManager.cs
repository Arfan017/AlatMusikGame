using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button GameLv2, GameLv3;
    public GameObject lock2, lock3;
    public AudioSource myAudioSource;
    int TrueAnswer, IsComplete;
    private bool QuizFinish;


    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void Start()
    {
        myAudioSource.volume = PlayerPrefs.GetFloat("musicVolume");

        GameLv2.interactable = false;
        GameLv3.interactable = false;
        QuizFinish = intToBool(PlayerPrefs.GetInt("QuizFinish"));
        IsComplete = PlayerPrefs.GetInt("IsComplete");

        if (QuizFinish)
        {
            GameLv2.interactable = true;
            lock2.SetActive(false);
        }

        if (IsComplete == 1)
        {
            GameLv3.interactable = true;
            lock3.SetActive(false);
        }
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
