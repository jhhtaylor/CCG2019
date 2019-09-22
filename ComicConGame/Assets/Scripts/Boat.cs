using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boat : MonoBehaviour
{
    [SerializeField] private float maxForward = 4;
    [SerializeField] private float maxLateral = 4;
    [SerializeField] private Vector2 oreForce;
    [SerializeField] private Vector2 drag;
    [SerializeField] private Material water;
    private float _currentForwardSpeed = 65f;
    private float _currentLateralSpeed;
    private float _posZ;
    [SerializeField] private float shaderScale = 0.5f;
    [SerializeField] private GameObject man;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Image hundred;
    [SerializeField] private Image ten;
    [SerializeField] private Image unit;
    [SerializeField] private Sprite[] digits;
    public float X => transform.position.x;
    public float Y => transform.position.y;
    public float Z => _posZ;

    private Quaternion _initialRotation;
    private bool _crash;

    private void Start()
    {
        _initialRotation = man.transform.rotation;
    }

    private float fallY = 0;
    private void Update()
    {
        if (!_crash)
        {
            if (Input.GetButtonDown("RightOre"))
            {
                sr.flipX = false;
            }

            if (Input.GetButtonDown("LeftOre"))
            {
                sr.flipX = true;
            }

            if (Input.GetButton("RightOre"))
            {
                Force(oreForce.x);
                man.transform.rotation = _initialRotation * Quaternion.Euler(0, 0, -30);
                man.transform.position =
                    new Vector3(transform.position.x, transform.position.y, man.transform.position.z);
            }
            else if (Input.GetButton("LeftOre"))
            {
                Force(-oreForce.x);
                man.transform.rotation = _initialRotation * Quaternion.Euler(0, 0, 30);
                man.transform.position =
                    new Vector3(transform.position.x - 1, transform.position.y, man.transform.position.z);
            }
            else
            {
                man.transform.rotation = _initialRotation;
            }

            Drag();
            _posZ += _currentForwardSpeed * Time.deltaTime;
            transform.position += _currentLateralSpeed * Time.deltaTime * Vector3.right;
            water.SetVector("_BoatPosition",
                new Vector4(0, _posZ * shaderScale));
            hundred.sprite = digits[(int) ((_posZ / 10) % 1000 / 100)];
            ten.sprite = digits[(int) ((_posZ / 10) % 100 / 10)];
            unit.sprite = digits[(int) ((_posZ / 10) % 10)];
        }
        else
        {
            fallY += 6 * Time.deltaTime;
            man.transform.Rotate(0,0,360*Time.deltaTime);
            man.transform.position = new Vector3(transform.position.x, transform.position.y-fallY, transform.position.z);
        }
    }

    private void Drag()
    {
        _currentLateralSpeed *= 1 - drag.x;
    }

    public void Crash()
    {
        _currentForwardSpeed = 0;
        _crash = true;
    }

    private void Force(float x)
    {
        _currentLateralSpeed += x * Time.deltaTime;
        _currentLateralSpeed = Mathf.Clamp(_currentLateralSpeed, -maxLateral, maxLateral);
    }
}