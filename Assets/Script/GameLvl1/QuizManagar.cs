using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManagar : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public Sprite imageQuestion;
        public List<string> options;
        public int correctOptionIndex;
    }

    public List<Question> questions;
    public TextMeshProUGUI questionText;
    public Image imageQuestion;
    public List<Button> optionButtons;
    public GameObject health0, health1, health2;
    public GameObject PanelMenang, PanelKalah;
    public AudioSource myAudioSource;
    private int currentQuestionIndex;
    private int health;
    private bool isAnswered;
    private bool QuizFinish;
    // private int TrueAnswer;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    void Start()
    {
        myAudioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        Health = 3;
        // TrueAnswer = 0;
        QuizFinish = false;
        health0.gameObject.SetActive(true);
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        // health3.gameObject.SetActive(true);

        currentQuestionIndex = 0;
        isAnswered = false;
        // ShuffleQuestions();
        ShowQuestion();
    }

    // void Update()
    // {

    // currentQuestionIndex = 0;
    // isAnswered = false;
    // ShuffleQuestions();
    // ShwQuestion();
    // textNilai.text = "Nilai: " + CalculateScore();
    // }

    void ReduceHealth()
    {
        Health -= 1;
        switch (Health)
        {
            case 3:
                health0.gameObject.SetActive(true);
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                break;

            case 2:
                health0.gameObject.SetActive(false);
                break;

            case 1:
                health1.gameObject.SetActive(false);
                break;

            case 0:
                health2.gameObject.SetActive(false);
                ShowPanelKalah();
                break;
        }
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionText.text = currentQuestion.questionText;
            imageQuestion.sprite = currentQuestion.imageQuestion;

            for (int i = 0; i < optionButtons.Count; i++)
            {
                if (i < currentQuestion.options.Count)
                {
                    optionButtons[i].gameObject.SetActive(true);
                    optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                }
                else
                {
                    optionButtons[i].gameObject.SetActive(false);
                }
            }
            isAnswered = false;
        }
        else
        {
            if (Health != 0)
            {
                ShowPanelMenang();
            }
            // textNilai.text = "Nilai: " + CalculateScore();
        }
    }

    public void OnOptionSelected(int optionIndex)
    {
        if (!isAnswered)
        {
            isAnswered = true;

            Question currentQuestion = questions[currentQuestionIndex];

            if (optionIndex == currentQuestion.correctOptionIndex)
            {
                // textNilai.text = "Nilai: " + CalculateScore();
                // TrueAnswer += 1;
            }

            else
            {
                ReduceHealth();
            }
            NextQuestionWithDelay();
        }
    }

    public void NextQuestionWithDelay()
    {
        currentQuestionIndex++;
        ShowQuestion();
    }

    // public int CalculateScore()
    // {
    //     int score = 0;

    //     foreach (Question question in questions)
    //     {
    //         if (question.correctOptionIndex == 0)
    //         {
    //             score++;
    //         }
    //     }
    //     return score;
    // }

    public void ShowPanelMenang()
    {
        Time.timeScale = 0;
        QuizFinish = true;
        PlayerPrefs.SetInt("QuizFinish", boolToInt(QuizFinish));
        PanelMenang.SetActive(true);
    }

    public void ShowPanelKalah()
    {
        Time.timeScale = 0;
        PanelKalah.SetActive(true);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }
    
    // public void StopAudio()
    // {
    //     audioBossFight.Stop();
    // }

    // IEnumerator LoadAsynchronously(int sceneIndex)
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    //     loadingPanel.SetActive(true);
    //     while (!operation.isDone)
    //     {
    //         float progress = Mathf.Clamp01(operation.progress / .9f);
    //         SliderLoading.value = progress;
    //         yield return null;
    //     }
    // }

    // public void ShuffleQuestions()
    // {
    //     List<Question> shuffledQuestions = new List<Question>();

    //     List<int> questionIndices = new List<int>();
    //     for (int i = 0; i < questions.Count; i++)
    //     {
    //         questionIndices.Add(i);
    //     }

    //     while (questionIndices.Count > 0)
    //     {
    //         int randomIndex = Random.Range(0, questionIndices.Count);
    //         int questionIndex = questionIndices[randomIndex];
    //         shuffledQuestions.Add(questions[questionIndex]);
    //         questionIndices.RemoveAt(randomIndex);
    //     }

    //     questions = shuffledQuestions;
    // }
}