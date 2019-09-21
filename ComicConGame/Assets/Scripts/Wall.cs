using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int LayerIndex { get; set; }

    private River _river;
    private Boat _boat;
    private float startZ;
    public float deleteDist = 2f;

    private void Start()
    {
        _river = FindObjectOfType<River>();
        _boat = FindObjectOfType<Boat>();
        startZ = _river.triggerDistance * LayerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var z = startZ - _boat.Z;
        if (z > -deleteDist)
            transform.position = new Vector3(pos.x, pos.y, z);
        else
            Destroy(gameObject);
    }
}