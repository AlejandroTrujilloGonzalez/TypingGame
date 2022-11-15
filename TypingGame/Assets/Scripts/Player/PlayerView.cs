using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Life")]
    [SerializeField]
    private int initialPlayerLife;
    [SerializeField]
    private int nHearts;

    [Header("Hearts Sprites")]
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    [Header("Blink")]
    public Color blinkColor;
    public Color regularColor;
    public float blinkDuration;
    public int nOfBlinks;
    public Collider2D triggerCollider;
    public SpriteRenderer playerSprite;


    private void Awake()
    {
        playerController = new PlayerController(initialPlayerLife);
    }

    private void Update()
    {
        playerController.HeartSystem(playerController.GetLifes(), nHearts, hearts, fullHeart, emptyHeart);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.DecreaseLifes();
            Destroy(collision.gameObject); //this will be better with a object pool
            Debug.Log("hit " + playerController.GetLifes());
        }
    }

    private IEnumerator Blink()
    {
        int i = 0;
        triggerCollider.enabled = false;
        while (i < nOfBlinks)
        {
            playerSprite.color = blinkColor;
            yield return new WaitForSeconds(blinkDuration);
            playerSprite.color = regularColor;
            yield return new WaitForSeconds(blinkDuration);
            i++;
        }
        triggerCollider.enabled = true;
    }
}
