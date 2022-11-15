using UnityEngine;
using UnityEngine.UI;

public class PlayerController
{
    private PlayerModel model;

    public PlayerController(int playerLife)
    {
        model = new PlayerModel(playerLife);
    }

    public void HeartSystem(int health, int nHearts, Image[] hearts, Sprite fullHeart, Sprite emptyHeart)
    {

        if (health > nHearts)        
            health = nHearts;        

        for (int i = 0; i < hearts.Length; i++)
        {
            //Check that show empty or full hearts
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
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

    public int GetLifes()
    {
        return model.PlayerLife;
    }

    public void DecreaseLifes()
    {
        model.PlayerLife--;
    }
}
