using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public Text wordOutput = null;

    private TouchScreenKeyboard keyboard;

    private string remainingWord = string.Empty;
    private string currentWord = "testing";

    // Start is called before the first frame update
    void Start()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        SetCurrentWord();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void SetCurrentWord()
    {
        //Get bank word
        SetRemainingWord(currentWord);

    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void CheckInput()
    {
        //Mobile
        if (keyboard.text.Length >= 1)
        {
            string keysPressed = keyboard.text;
            Debug.Log(keysPressed);
            EnterLetter(keysPressed);
            keyboard.text = "";          
        }

        //PC
        //if (Input.anyKeyDown)
        //{
        //    string keysPressed = Input.inputString;
        //    Debug.Log(keysPressed);
        //    if (keysPressed.Length == 1)
        //    {
        //        EnterLetter(keysPressed);
        //    }
        //}
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsLetterCorrect(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool IsLetterCorrect(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
