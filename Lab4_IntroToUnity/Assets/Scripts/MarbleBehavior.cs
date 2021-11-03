﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float rotateSpeed = 15f;
    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;
    
    private float fbInput;
    private float lrInput;
    
    private Rigidbody _rb;
    
    private SphereCollider _col;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
//        _rb = GetComponent<Rigidbody>();
      _rb = GetComponent<Rigidbody>();
      _col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
      fbInput = Input.GetAxis("Vertical") * moveSpeed;
      lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }
    
    void FixedUpdate()
    {
      if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
      {
        _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
      }

      Vector3 rotation = Vector3.up * lrInput;
      Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
      _rb.MovePosition(this.transform.position +
        this.transform.forward * fbInput * Time.fixedDeltaTime);
      _rb.MoveRotation(_rb.rotation * angleRot);
        //Put code that moves the sprite using the RigidBody here
    }

    void OnCollisionEnter(Collision collision)
    {
      //Put collision code here
      _rb.freezeRotation = true;
    }

    private bool IsGrounded()
    { 
      Vector3 sphereBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);

      bool grounded = Physics.CheckSphere(sphereBottom, distanceToGround,
        groundLayer, QueryTriggerInteraction.Ignore);
      
      return grounded;
    }
    
}
