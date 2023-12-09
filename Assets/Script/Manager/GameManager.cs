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
    int TrueAnswer;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void Start() {
        GameLv2.interactable = false;
        GameLv3.interactable = false;
        TrueAnswer = PlayerPrefs.GetInt("TrueAnswer");
        Debug.Log("Bro");

        if (TrueAnswer == 6)
        {
            GameLv2.interactable = true;
            lock2.SetActive(false);
        }

    }
    
}
