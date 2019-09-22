using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rail
{
    private List<Vector2> _path;
    private float _layerDifference;
    private Vector2 defaultVal;

    public Rail(float layerDifference, Vector2 defaultVal)
    {
        this.defaultVal = defaultVal;
        _layerDifference = layerDifference;
        _path = new List<Vector2>();
    }

    public void Add(Vector2 point)
    {
        _path.Add(point);
    }

    public void RemoveFirst()
    {
        _path.RemoveAt(0);
    }

    public Vector3 Eval(float z)
    {
        float p = (z) / _layerDifference;
        int i = (int) p;
        var t = 1 - (p - i);

        var xy = Vector2.Lerp(
            i >= 0 && i < _path.Count ? _path[i] : defaultVal,
            i > 0 && i <= _path.Count ? _path[i - 1] : defaultVal,
            t);

        return new Vector3(xy.x, xy.y, z);
    }

    public void SetPoints(List<Vector2> points)
    {
        _path = points;
    }
}

public class Wall : MonoBehaviour
{
    public Boat _boat;
    private float startZ;
    private bool _flip;
    public float deleteDist = 2f;
    private Rail _scaleRail;
    private Rail _posRail;
    public float yMax = 11f;
    [SerializeField] private List<Vector2> posRail;
    
    public void Set(int layerIndex, float triggerDistance, int riverLength, Boat boat, float x)
    {
        if (Random.Range(0, 1f) < 0.5f)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
        }
        _boat = boat;
        startZ = triggerDistance * layerIndex;
        var z = startZ - _boat.Z;
        _posRail = new Rail(triggerDistance, new Vector2(x,0));
        for (int i = 0; i < riverLength - 6; i++)
        {
            _posRail.Add(Vector2.Lerp(Vector2.right * x, new Vector2(x,yMax), (float)i/(riverLength-7)));
        }
        transform.position = _posRail.Eval(z);
    }

    // Update is called once per frame
    void Update()
    {
        var z = startZ - _boat.Z;
        if (z > -deleteDist)
        {
            transform.position = _posRail.Eval(z);
        }
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Awe");
            other.gameObject.GetComponent<Boat>().Crash();
        }
    }
}