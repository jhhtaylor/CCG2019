using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string Game;
    public Image play;
    public Image quit;
    public Image flower;
    public float time = 0.5f;
    private float _timer = 0;
    private Sprite playDefault;
    private Sprite quitDefault;
    private Sprite flowerDefault;
    public Sprite playOther;
    public Sprite quitOther;
    public Sprite flowerOther;
    private bool swap;
    private int selection;

    private void Start()
    {
        playDefault = play.sprite;
        quitDefault = quit.sprite;
        flowerDefault = flower.sprite;
    }

    void Update()
    {
        //----------------------------------------------------
        if (_timer < 0)
        {
            Swap();
            _timer = time;
        }
        //----------------------------------------------------
        else
        {
            _timer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Down"))
        {
            selection++;
            if (selection == 2) selection = 0;
            UpdateFlowers();
        }
        else if (Input.GetButtonDown("Up"))
        {
            selection--;
            if (selection == -1) selection = 1;
            UpdateFlowers();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (selection == 0)
            {
                StartGame();
            }
            else if (selection == 1)
            {
                QuitGame();
            }
        }
    }

    private void UpdateFlowers()
    {
        flower.gameObject.transform.position =
            selection == 0 ? play.gameObject.transform.position : quit.transform.position;
    }

    private void Swap()
    {
        swap = !swap;
        play.sprite = swap ? playOther : playDefault;
        quit.sprite = swap ? quitOther : quitDefault;
        flower.sprite = swap ? flowerOther : flowerDefault;
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