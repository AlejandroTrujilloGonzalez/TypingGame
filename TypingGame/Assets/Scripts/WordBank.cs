using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    //Try to do the list with firebase or a text file
    private List<string> OriginalWords = new List<string>()
    {
        "probando", "escribe", "dale"
    };

    private List<string> WorkingWords = new List<string>();

    private void Awake()
    {
        WorkingWords.AddRange(OriginalWords);
        Shuffle(WorkingWords);
        ConvertToLower(WorkingWords);        
    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

    //To make shure that all words are in lower case, no matter the source
    private void ConvertToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (WorkingWords.Count != 0)
        {
            newWord = WorkingWords.Last();
            WorkingWords.Remove(newWord);
        }

        return newWord;
    }
}
