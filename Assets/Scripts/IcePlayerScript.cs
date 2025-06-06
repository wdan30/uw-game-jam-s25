using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D iceRigidbody;
    [SerializeField] private float iceSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("iceHorizontal");
        
        iceRigidbody.velocity += Vector2.right * horizontalInput * iceSpeed;
    }
}
