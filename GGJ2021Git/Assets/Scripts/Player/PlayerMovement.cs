using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    private CharacterController _controller;

    [SerializeField] private float _speed = 12f;
    [SerializeField] float _gravity = -9.81f;


    [SerializeField] private Transform _gCheck;
    [SerializeField] private float _gDistancel;
    [SerializeField] private LayerMask _gMask;


    Vector3 velocity;
    [SerializeField] bool _isGrounded;


    void Start()
    {
        _controller = GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check
        _isGrounded = Physics.CheckSphere(_gCheck.position , _gDistancel , _gMask);

        if(_isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Movement
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);

        //Gravity
        velocity.y += _gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);


    }
}
