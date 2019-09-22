using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    public static DontDestroyMusic Instance;
    
    
    
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //dont destroy the music across scenes
        DontDestroyOnLoad(transform.gameObject);
    }

}
