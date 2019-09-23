using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public float speed;
    public bool destroy = false;
    private float angle;
    private bool _rotateToTop;
    private bool _rotateToBottom;
    private bool _isUp;
    public bool alwaysRotate;

    private void Start()
    {
    
        transform.rotation = Quaternion.Euler(0, 0, 180f);
        
    }

    private void Update()
    {
        if (_rotateToTop && Mathf.Abs(transform.eulerAngles.z) > 180)
        {
            _isUp = true;
            _rotateToTop = false;
            _rotateToBottom = false;
        }
        
        if (_rotateToBottom && Mathf.Abs(angle) >= 360)
        {
            if(destroy)
                Destroy(gameObject);
            else
            {
                angle = 0;
                _isUp = false;
                _rotateToBottom = false;
                _rotateToTop = false;
            }
        }

        if (_rotateToTop || _rotateToBottom || alwaysRotate)
        {
            angle += speed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0, 0, -speed * Time.deltaTime);
        }
    }

    public void RotateToTop()
    {
        _rotateToTop = true;
    }

    public void RotateToBottom()
    {
        _rotateToBottom = true;
    }
    
    
    

    public bool IsUp()
    {
        return _isUp;
    }
}