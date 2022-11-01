using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
   public void ExitGame ()
    {
        Debug.Log("See u next time!");
        Application.Quit();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void HangmanMode()
    {
        SceneManager.LoadScene("HangmanTutorial");
    }
    public void StartMatch()
    {
        SceneManager.LoadScene("Matching");
    }

    public void StartHangman()
    {
        SceneManager.LoadScene("Hangman");
    }

    public void MatchingTutorial()
    {
        SceneManager.LoadScene("MatchingTutorial");
    }

}