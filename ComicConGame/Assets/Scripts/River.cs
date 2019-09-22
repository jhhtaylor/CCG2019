using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class River : MonoBehaviour
{
    [SerializeField] private Wall[] wallPrefabs;
    [SerializeField] private Boat boat;
    [SerializeField] private float variance = 2f;
    public int riverLength = 10;
    public float triggerDistance;
    private int _nextLayer = 1;
    private float _currentDistance;
    private float x;

    private void Start()
    {
        
        _currentDistance = triggerDistance;
        for (var i = 0; i < riverLength; i++)
        {
            GenerateNextLayer();
        }
    }

    public void Update()
    {
        if (_currentDistance - boat.Z < 0)
        {
            _currentDistance += triggerDistance;
            GenerateNextLayer();
        }
    }


    private void GenerateNextLayer()
    {
        Wall a = Instantiate(wallPrefabs[Random.Range(0,wallPrefabs.Length)], Vector3.zero, Quaternion.identity).GetComponent<Wall>();
        a.Set(_nextLayer, triggerDistance, riverLength, boat, x);
        x += Random.Range(-variance, variance);
        _nextLayer++;
    }
}