using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typer : MonoBehaviour
{

    public WordBank wordBank;

    public TextMeshProUGUI wordOutput;
    public TMP_InputField wordInput;

    private TouchScreenKeyboard keyboard;

    private string remainingWord;
    private string currentWord;

    // Start is called before the first frame update
    void Start()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);

    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (wordInput.text == wordOutput.text)
        {
            wordInput.text = "";
            SetCurrentWord();
            //earn score
            //shoot fireballs
        }
    }


}
