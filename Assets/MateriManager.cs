using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MateriManager : MonoBehaviour
{
    public GameObject panelMateri1;
    public GameObject panelMateri2;
    public GameObject panelMateri3;
    private void Start()
    {
        panelMateri1.SetActive(false);
        panelMateri2.SetActive(false);
        panelMateri3.SetActive(false);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
