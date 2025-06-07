using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IcePlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D iceBody;
    [SerializeField] private float iceSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float horizontalFriction;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private BoxCollider2D iceCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float jumpStrength;
   
    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("I am ice");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            iceBody.velocity = new Vector2(0, iceBody.velocity.y);
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            iceBody.velocity += Vector2.up * jumpStrength;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }

        horizontalSpeed = iceBody.velocity.magnitude;

        float currX = iceBody.velocity.x;
        
        iceBody.velocity += Vector2.right * horizontalInput * iceSpeed * (1 - Math.Abs(currX) / maxSpeed);

        if (Math.Abs(horizontalInput) == 0)
        {
            float speedDamp = (Math.Abs(currX) / maxSpeed);
            iceBody.velocity = new Vector2(currX * horizontalFriction, iceBody.velocity.y);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(iceCollider.bounds.center, iceCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        RaycastHit2D playerCheck = Physics2D.BoxCast(iceCollider.bounds.center, iceCollider.bounds.size, 0, Vector2.down, 0.1f, playerLayer);

        if (playerCheck.collider != null)
        {
            var otherPlayer = playerCheck.collider.gameObject;
            Debug.Log("Player detected: " + otherPlayer.name);
            if (iceCollider.bounds.center.y > otherPlayer.GetComponent<Collider2D>().bounds.center.y)
            {
                return true;
            }
        }

        return groundCheck.collider != null;
    }
}
