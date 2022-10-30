using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public char letter;
    public GameManager manager;
    // Start is called before the first frame update
    private void Awake()
    {
        text.text = "";
    }

    private void Update()
    {
        if(Input.GetKeyDown(letter.ToString().ToLower()))
        {
            if(text.text == "")
            {
                text.text = letter.ToString().ToUpper();
                manager.left--;
                manager.success = true;
            }
        }
    }

    public void ShowLetter()
    {
        if (text.text == "")
        {
            text.text = letter.ToString().ToUpper();
            text.alpha = 0.5f;
        }
    }
}
