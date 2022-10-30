using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string[] words;
    public Transform letterTemplate;
    public Transform wordParent;
    
    public int left;
    public bool success;
    
    public List<char> tried;
    public TextMeshProUGUI triedText;
    
    public Image hangmanImage;
    public Sprite[] hangman;
    public int hangmanSprite;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        char[] word = words[UnityEngine.Random.Range(0, words.Length)].ToCharArray();

        foreach (char letter in word)
        {
            if (char.IsLetterOrDigit(letter))
            {
                Letter letterScript = Instantiate(letterTemplate, wordParent).GetComponent<Letter>();
                letterScript.letter = letter;
                letterScript.manager = this;
            }
        }
    }

    private void Update()
    {
        if (left == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        else if (Input.anyKeyDown)
        {
            char input = Input.inputString.ToCharArray()[0];
            if (char.IsLetterOrDigit(input))
            {
                if(!tried.Contains(input))
                {
                    tried.Add(input);
                    if(!success)
                    {
                        triedText.text += input.ToString().ToUpper() + ", ";

                        hangmanSprite++;
                        if (hangmanSprite >= 11)
                        {
                            hangmanSprite = 11;
                            Lost();
                        }
                        hangmanImage.sprite = hangman[hangmanSprite];
                    }
                    success = false;
                }
            }
        }
    }

    public void Lost()
    {
        for (int i = 0; i < wordParent.childCount; i++)
        {
            wordParent.GetChild(i).GetComponent<Letter>().ShowLetter();
        }
        left = 0;
    }
}
