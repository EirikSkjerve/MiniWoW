using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        GetMovement();
        //player.SetCurrentTarget(GetClick());
        ListenForClicks();
    }

    private void GetMovement()
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
        player.transform.Translate(movementDirection * (player.GetRunSpeed() * inputMagnitude * Time.deltaTime),
            Space.World);

        //updates the enum Direction of the player, given the calculated movementDirection vector.
        player.SetCurrentDirection(movementDirection);
    }

    void ListenForClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TargetClickTarget();
        }
    }

    void TargetClickTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider == null) return;
        //Debug.Log(hit.collider.gameObject.ToString());
        GameObject o;
        var objectType = (o = hit.collider.gameObject).GetType();
        // Check if the clicked object is a valid target
        // Set the current target
        Debug.Log(objectType.ToString());
        player.SetCurrentTarget(o);

        // Perform any additional actions or effects on the target
        // For example, change the sprite color or play a sound
        // ...
    }
}