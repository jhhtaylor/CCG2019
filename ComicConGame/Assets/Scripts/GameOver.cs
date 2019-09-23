using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isGameOver = false;
    public GameObject gameOverPanel;
    public Boat _boat;
    public string Menu;
    /// Use this for initialization
    void Start()
    {
     
    }

    void FixedUpdate()
    {
        ///game is over if no lives
        if (_boat.getCrash())
        {
            SetGameOver();
            isGameOver = true;
        }
    }
    /// Update is called once per frame
    void Update()
    {
        ///restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        ///escape to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(Menu);
        }
     
    }

    public void SetGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        //SceneManager.LoadScene(1);
 
    }

    public void Escape()
    {
        //SceneManager.LoadScene(MenuScreen);
        //Time.timeScale = 1;
    }

    public void Pause()
    {
        //P.pauseGame();
    }

}
