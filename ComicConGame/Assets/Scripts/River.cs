using System;
using System.Collections.Generic;
using UnityEngine;


public class River : MonoBehaviour
{
    [SerializeField] private int riverLength = 10;
    [SerializeField] private Wall wallPrefabs;
    private Boat _boat;
    private int nextLayer = 1;
    public float triggerDistance;
    private float _currentDistance;

    private void Start()
    {
        _boat = FindObjectOfType<Boat>();
        _currentDistance = triggerDistance;
        for (var i = 0; i < riverLength; i++)
        {
            GenerateNextLayer();
        }
    }

    public void Update()
    {
        if (_currentDistance - _boat.Z < 0)
        {
            _currentDistance += triggerDistance;
            GenerateNextLayer();
        }
    }


    private void GenerateNextLayer()
    {
        var a = Instantiate(wallPrefabs, new Vector3(-15, 0, 0), Quaternion.identity);
        var b = Instantiate(wallPrefabs, new Vector3(15, 0, 0), Quaternion.identity);
        a.LayerIndex = nextLayer;
        b.LayerIndex = nextLayer;
        nextLayer++;
    }
}