using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class playerFollow : MonoBehaviour
{
    public Rigidbody2D target;
    public float smoothTime = 0.05f;
    private Vector2 currentVelocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the object
        Vector2 currentPosition = transform.position;

        // Calculate the new position using SmoothDamp
        Vector2 newPosition = Vector2.SmoothDamp(currentPosition, target.position, ref currentVelocity, smoothTime);

        // Move the object to the new position
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
