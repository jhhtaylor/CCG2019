using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaftAnimate : MonoBehaviour
{
    public GameObject Man;
    public float moveLeft = -1.6f;
    private Vector3 rotationVector;
    public float time = 0.5f;
    private float _timer = 0;
    void Start()
    {
        rotationVector = Man.transform.rotation.eulerAngles;
        Man.transform.position = new Vector3(0, 0, 0);
    }


    void Update()
    {
        //RIGHT
        if (Input.GetKeyDown(KeyCode.D)&&_timer<=0)
        {
            rotationVector = new Vector3(0, 0, -30);
            Man.transform.rotation = Quaternion.Euler(rotationVector);
            _timer = time;
        }
        //LEFT
        if (Input.GetKeyDown(KeyCode.A)&& _timer<=0)
        {
            Man.transform.position = new Vector3(moveLeft, 0, 0);

            rotationVector = new Vector3(0, 180, -30);
            Man.transform.rotation = Quaternion.Euler(rotationVector);
            _timer = time;
            //Man.transform.rotation += new Vector3(0, 0, 30);
          
        }

        if (_timer < 0)
        {
            Man.transform.rotation = Quaternion.Euler(0,Man.transform.rotation.eulerAngles.y, 0);
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
