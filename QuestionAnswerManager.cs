using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;


public class QuestionAnswerManager : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public QAClass07[] qaArray;
    public GameObject AnswerPanel;
    private GameController gameController;
    private int Counter = 0;
    public string filepath  = @"C:\Users\sedlm\Desktop\";
    private List<string[]> rowData = new List<string[]>();
    private DataController dataController;

    // Start is called before the first frame update
    void Start()
    {
        qaArray = new QAClass07[questionGroupArr.Length];
        Debug.Log("beginning is happening");
        gameController = FindObjectOfType<GameController>();
        dataController = FindObjectOfType<DataController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitAnswer()
    {
  
       if(Counter < questionGroupArr.Length - 1) { 
            qaArray[Counter] = ReadQuestionAndAnswer(questionGroupArr[Counter]);
            Counter++;
            gameController.AnswerButtonClicked();
       }
       else
        {
            qaArray[Counter] = ReadQuestionAndAnswer(questionGroupArr[Counter]);
            saveData(qaArray);
            gameController.AnswerButtonClicked();
            Counter = 1;

        }
         
    }
   

    public void saveData(QAClass07[] qa)
    {
        
        try
        {

            string username = dataController.userName;
          
            using (StreamWriter file = File.CreateText(filepath + username + "_SavedData.csv"))
            {
                
                   
                    string[] rowDataTemp = new string[3];
                    rowDataTemp[0] = "Question";
                    rowDataTemp[1] = "Answer";
                   
                    rowData.Add(rowDataTemp);

                for (int i = 0; i < qa.Length; i++)
                {
                     rowDataTemp = new string[2];
                     rowDataTemp[0] = qa[i].Question; 
                     rowDataTemp[1] = qa[i].Answer; 
                   
                     rowData.Add(rowDataTemp);
                }

                string[][] output = new string[rowData.Count][];

                    for (int i = 0; i < output.Length; i++)
                    {
                        output[i] = rowData[i];
                    }

                    int length = output.GetLength(0);
                    string delimiter = ",";

                    StringBuilder sb = new StringBuilder();

                    for (int index = 0; index < length; index++)
                        sb.AppendLine(string.Join(delimiter, output[index]));
             

                    
                    file.WriteLine(sb);
                    file.Close();

                    //ile.WriteLine(qa[i].Answer);
                }
                   
          

        }
        catch(Exception ex)
        {
            throw new ApplicationException("This program did an oopsie: " + ex);

        }
       

    }

    QAClass07 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass07 result = new QAClass07();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break;
                }
            }
        }



       
        return result;
    }


}

[System.Serializable]
public class QAClass07
{
    public string Question;
    public string Answer;
}
