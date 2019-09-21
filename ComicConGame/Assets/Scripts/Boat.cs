using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boat : MonoBehaviour
{
    [SerializeField] private float maxForward = 4;
    [SerializeField] private float maxLateral = 4;
    [SerializeField] private Vector2 oreForce;
    [SerializeField] private Vector2 drag;
    [SerializeField] private Material water;
    private float _currentForwardSpeed ;
    private float _currentLateralSpeed;
    private float _posZ;
    [SerializeField] private float shaderScale = 0.5f;

    public float Z => _posZ;

    private void Update()
    {
        if (Input.GetButtonDown("RightOre"))
        {
            Force(oreForce.x, 0, oreForce.y);
        }
        else if (Input.GetButtonDown("LeftOre"))
        {
            Force(-oreForce.x, 0, oreForce.y);
        }

        Drag();
        _posZ += _currentForwardSpeed * Time.deltaTime;
        transform.position += _currentLateralSpeed * Time.deltaTime * Vector3.right;
        water.SetVector("_BoatPosition",
            new Vector4(0, _posZ * shaderScale));
    }

    private void Drag()
    {
        _currentLateralSpeed *= 1 - drag.x;
        _currentForwardSpeed *= 1 - drag.y;
    }

    private void Force(float x, float y, float z)
    {
        _currentForwardSpeed += z;
        _currentForwardSpeed = Mathf.Clamp(_currentForwardSpeed, 0, maxForward);
        _currentLateralSpeed += x;
        _currentLateralSpeed = Mathf.Clamp(_currentLateralSpeed, -maxLateral, maxLateral);
    }
}