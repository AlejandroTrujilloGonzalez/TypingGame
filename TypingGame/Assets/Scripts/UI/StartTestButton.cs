using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTestButton : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    public void OpenMobileKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
