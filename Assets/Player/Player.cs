using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public Stats PlayerStats;
    [SerializeField] private float xDir;
    [SerializeField] private float yDir;
    // Start is called before the first frame update
    public override void Start()
    {
        PlayerStats = new Stats();
        PlayerStats.WalkSpeed = 2.5f;
        PlayerStats.RunSpeed = 6f;
    }

    // Update is called once per frame
    public override void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * (PlayerStats.RunSpeed * inputMagnitude * Time.deltaTime), Space.World);
    }
}
