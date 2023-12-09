using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelUtama;
    public GameObject panelMainmenu;
    public GameObject panelAbout;

    private void Awake()
    {
        panelMainmenu.SetActive(false);
        panelAbout.SetActive(false);

        PlayerPrefs.DeleteKey("TrueAnswer");
    }

    private void Start()
    {
        int statusPanelUtama = PlayerPrefs.GetInt("PanelUtamaTerbuka", 1); // 1 adalah nilai default jika kunci tidak ditemukan
        if (statusPanelUtama == 1)
        {
            // Panel utama terbuka
            // Tambahkan kode untuk membuka panel utama di sini
            panelUtama.SetActive(true);
        }
        else
        {
            panelUtama.SetActive(false);
            panelMainmenu.SetActive(true);
            // Panel utama tertutup
            // Tambahkan kode untuk menjaga panel utama tertutup di sini
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void DisablePanel()
    {
        panelUtama.SetActive(false);
        PlayerPrefs.SetInt("PanelUtamaTerbuka", 0); // 0 untuk menandakan bahwa panel utama tertutup
        PlayerPrefs.Save(); // Simpan perubahan
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("PanelUtamaTerbuka");
        PlayerPrefs.Save();
    }
}