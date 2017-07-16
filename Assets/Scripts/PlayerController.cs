using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fullSpeed;
    private float _speed;
    private float _startupTime;
    private Vector3 _velocity;
    private float _inputX;
    private float _inputY;
    // Use this for initialization
    void Start()
    {
        _fullSpeed = 0.1F;
        _speed = 0;
        _startupTime = 4.0F;
        _inputX = 0;
        _inputY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Boolean upPushed = (Input.GetKey(KeyCode.W) ? true : Input.GetKey(KeyCode.UpArrow));
        Boolean downPushed = (Input.GetKey(KeyCode.S) ? true : Input.GetKey(KeyCode.DownArrow));
        Boolean rightPushed = (Input.GetKey(KeyCode.D) ? true : Input.GetKey(KeyCode.RightArrow));
        Boolean leftPushed = (Input.GetKey(KeyCode.A) ? true : Input.GetKey(KeyCode.LeftArrow));


        if (Time.timeSinceLevelLoad < _startupTime)
        {
            _speed = _fullSpeed * (Time.timeSinceLevelLoad / _startupTime);
        }
        else
        {
            _speed = _fullSpeed;
        }
        if (upPushed || downPushed || leftPushed || rightPushed)
        {
            _inputX = leftPushed ? -1 : (rightPushed ? 1 : 0);
            _inputY = downPushed ? -1 : (upPushed ? 1 : 0);
        }

        _inputX = Convert.ToInt16((_inputX < 0) ? Math.Floor(_inputX) : Math.Ceiling(_inputX));
        _inputY = Convert.ToInt16((_inputY < 0) ? Math.Floor(_inputY) : Math.Ceiling(_inputY));

        _velocity.x = _inputX * _speed;
        _velocity.y = _inputY * _speed;

        transform.position += _velocity;

    }
}