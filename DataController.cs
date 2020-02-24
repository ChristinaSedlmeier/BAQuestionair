using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    public RoundData[] allRoundData;
    public string userName;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("InData Controller");
        DontDestroyOnLoad(gameObject); //when Loading new scene this Data will persist

        SceneManager.LoadScene ("MenuScene");

        
    }

    public RoundData GetCurrentRoundData()
    {
        Debug.Log("InData Controller");
        return allRoundData[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
