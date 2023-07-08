using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Player player;
    
    //collection of sprites. Later this should be in own script.
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    //the sprite renderer for the player object
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //todo write this in own script
        if (player.GetCurrentDirection() == Entity.Direction.Up)
            spriteRenderer.sprite = upSprite;
        else if (player.GetCurrentDirection() == Entity.Direction.Down)
            spriteRenderer.sprite = downSprite;
        else if (player.GetCurrentDirection() == Entity.Direction.Left)
            spriteRenderer.sprite = leftSprite;
        else if (player.GetCurrentDirection() == Entity.Direction.Right)
            spriteRenderer.sprite = rightSprite;
    }
}
