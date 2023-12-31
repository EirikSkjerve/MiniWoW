using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets input from user. 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // a movement direction vector being a linear combination of basis vectors (0,1) (1,0) and the zero-vector (0,0)
        // Either: (0,0), (0,1), (1,0), (1,1), (0,-1), (-1,0), (-1,-1), (1,-1), or (-1,1)
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        
        //movement is smoothed out
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        //vector is normalized
        movementDirection.Normalize();

        //changes the position of the player
        player.transform.Translate(movementDirection * (player.GetRunSpeed() * inputMagnitude * Time.deltaTime), Space.World);
        
        //updates the enum Direction of the player, given the calculated movementDirection vector.
        player.SetCurrentDirection(movementDirection);

        
    }
}