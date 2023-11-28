using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MateriManager : MonoBehaviour
{
    public GameObject panelIlmu;
    public Button tombol1;
    public Button tombol2;
    public Image imageAlat;
    public TextMeshProUGUI tittle;
    public TextMeshProUGUI content;
    public Scrollbar scrollbar;
    public AlatMusik[] alatMusiks;

    void Start()
    {
        panelIlmu.SetActive(false);
        tombol1.onClick.AddListener(() => TampilkanMateri(0));
        tombol2.onClick.AddListener(() => TampilkanMateri(1));
    }

    public void TampilkanMateri(int indeks)
    {
        if (indeks >= 0 && indeks < alatMusiks.Length)
        {
            AlatMusik alatMusik = alatMusiks[indeks];
            panelIlmu.SetActive(true);
            // scrollbar.value = 0f;
            tittle.text = alatMusik.nama;
            content.text = alatMusik.materi;
            imageAlat.sprite = alatMusik.image;
        }
        else
        {
            Debug.LogWarning("Indeks diluar batas array!");
        }
    }
}
