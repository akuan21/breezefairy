using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text playerDisplay;
    private void Start()
    {if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player:" + DBManager.username;

        }
        
    }
    public void PlayGame ()
    {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    public void QuitGame()
    {SceneManager.LoadScene("game is quit");
        Application.Quit();}
    public void BackButton()
    { SceneManager.LoadScene("1 welcomePage"); }
}
