using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoat : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    private Boat _boat;

    // Start is called before the first frame update
    void Start()
    {
        _boat = FindObjectOfType<Boat>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = _boat.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(position.x, transform.position.y, transform.position.z), speed);
    }
}