using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{
    public string Vorname;
    public string Nachname;

    public void StartGame()
    {
   
        SceneManager.LoadScene("GameScene");
    }

  
}
