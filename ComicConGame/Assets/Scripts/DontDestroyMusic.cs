using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{

    void Awake()
    {
        //dont destroy the music across scenes
        DontDestroyOnLoad(transform.gameObject);
    }

}
