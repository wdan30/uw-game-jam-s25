using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MeatPlayerScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D meatCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D meatBody;
    [SerializeField] private float meatSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float horizontalFriction;
   
    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("I am meat");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            meatBody.velocity = new Vector2(0, meatBody.velocity.y);
        } 
        else if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            Debug.Log("Jump");
            meatBody.velocity += Vector2.up * 10;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }

        float currX = meatBody.velocity.x;
        
        meatBody.velocity += Vector2.right * horizontalInput * meatSpeed * (1 - Math.Abs(currX) / maxSpeed);

        if (Math.Abs(horizontalInput) == 0)
        {
            meatBody.velocity = new Vector2(currX * horizontalFriction, meatBody.velocity.y);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(meatCollider.bounds.center, meatCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
