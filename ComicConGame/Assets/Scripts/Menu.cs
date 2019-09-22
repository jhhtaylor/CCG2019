using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string Game;
    public float time = 0.5f;
    private float _timer = 0;
    private bool background1Check = true;
    public Image background1;
    public Image background2;

    void Update()
    {
        //start
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Game);
        }
        //quit
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        //----------------------------------------------------
        if (_timer < 0)
        {
            //change to BG2
            if(background1Check)
            {
                background2.gameObject.SetActive(true);
                background1.gameObject.SetActive(false);
                background1Check = false;
            }
            else //change to BG1
            {
                background1.gameObject.SetActive(true);
                background2.gameObject.SetActive(false);
                background1Check = true;
            }
            _timer = time;
        }
        //----------------------------------------------------
        else
        {
            _timer -= Time.deltaTime;
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene(Game);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
