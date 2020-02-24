using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{


    public Text questionDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;


    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private MenuScreenController menuScreenController;


 
    private int questionIndex;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        Debug.Log("InStart of GameController");
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        menuScreenController = FindObjectOfType<MenuScreenController>();

        

        questionIndex = 0;

        ShowQuestion();


    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;
        Debug.Log(questionPool[questionIndex]);

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            //GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            //answerButtonGameObjects.Add(answerButtonGameObject);
            //answerButtonGameObject.transform.SetParent(answerButtonParent);

            //AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            //answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked()
    {
        Debug.Log("AnswerButtonClicked");

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }

    }

    public void EndRound()
    {


        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }



    // Update is called once per frame
    void Update()
    {
       
    }
}