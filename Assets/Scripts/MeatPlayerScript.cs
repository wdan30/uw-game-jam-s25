using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeatPlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D meatBody;
    [SerializeField] private float meatSpeed;
    [SerializeField] private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("I am meat");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        meatBody.velocity += Vector2.right * horizontalInput * meatSpeed;

        if (meatBody.velocity.magnitude > maxSpeed)
        {
            meatBody.velocity *= maxSpeed / meatBody.velocity.magnitude;
        }

    }
}
