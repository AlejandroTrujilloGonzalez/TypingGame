using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    int health;
    public int nHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        health = GameManager.instance.health;

        //Check that health never be greater than number of hearts
        if (health > nHearts)
        {
            health = nHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            //Check that show empty or full hearts
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Check to show the number of hearts needed
            if (i < nHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
