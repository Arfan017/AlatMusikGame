using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PuzzelManager : MonoBehaviour
{
    public GameObject SelectedPiece;
    public Sprite newPuzzle;
    public AudioSource myAudioSource;
    private int RemeaningPlace = 16;
    int OIL = 1;

    public int RemeaningPlace_
    {
        get
        {
            return RemeaningPlace;
        }
        set
        {
            RemeaningPlace = value;
            if (RemeaningPlace_ == 0)
            {
                ShowPanelWin();
            }
        }
    }

    private void Start()
    {
        myAudioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null && hit.transform.CompareTag("Puzzle"))
            {
                PieceScript pieceScript = hit.transform.GetComponent<PieceScript>();
                if (pieceScript != null && !pieceScript.InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    pieceScript.Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && SelectedPiece != null)
        {
            PieceScript pieceScript = SelectedPiece.GetComponent<PieceScript>();
            if (pieceScript != null)
            {
                pieceScript.Selected = false;
            }
            SelectedPiece = null;
        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }

    public GameObject StartPanel, PanelMenang, PanelSelesai;
    public void SetPuzzlePhoto(Sprite Photo)
    {
        // string nextPuzzleName = PlayerPrefs.GetString("NextPuzzlePhoto", "");
        // // Debug.Log(nextPuzzleName);

        // if (!string.IsNullOrEmpty(nextPuzzleName))
        // {
        //     Photo = Resources.Load<Sprite>(nextPuzzleName);
        //     for (int i = 0; i < 36; i++)
        //     {
        //         Transform pieceTransform = GameObject.Find("Piece (" + i + ")")?.transform;
        //         if (pieceTransform != null)
        //         {
        //             Transform puzzleTransform = pieceTransform.Find("Puzzle");
        //             if (puzzleTransform != null)
        //             {
        //                 puzzleTransform.GetComponent<SpriteRenderer>().sprite = Photo;
        //             }
        //         }
        //     }
        //     PlayerPrefs.DeleteKey("NextPuzzlePhoto");
        // }
        // else
        // {
        // Debug.Log(nextPuzzleName);
        // Photo != null
        for (int i = 0; i < 36; i++)
        {
            Transform pieceTransform = GameObject.Find("Piece (" + i + ")")?.transform;
            if (pieceTransform != null)
            {
                Transform puzzleTransform = pieceTransform.Find("Puzzle");
                if (puzzleTransform != null)
                {
                    puzzleTransform.GetComponent<SpriteRenderer>().sprite = Photo;
                }
            }
        }
        StartPanel.SetActive(false);
        // }
    }

    public void NextPuzzle()
    {
        SceneManager.LoadSceneAsync(6);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.SetString("NextPuzzlePhoto", newPuzzle.name);
    }

    public void ShowPanelWin()
    {
        if (SceneManager.GetActiveScene().name == "GameLvl3 1")
        {
            PanelMenang.SetActive(true);
        }
        else
        {
            PanelSelesai.SetActive(true);
        }
    }

    public void ExitGame(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}