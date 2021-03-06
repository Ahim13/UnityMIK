﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager4 : MonoBehaviour
{
    public static GameManager4 Instance;

    [SerializeField] private GameObject[] _lives;
    [SerializeField] private Text _scoreText;

    private int _livesCounter = 3;

    private static int _POINTS = 0;
    
    public int LivesCounter
    {
        get { return _livesCounter; }
        private set { _livesCounter = value; }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetGame();
    }

    public void Died()
    {
        _livesCounter--;
        _lives[_livesCounter].SetActive(false);

        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (_livesCounter == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResetGame()
    {
        _POINTS = 0;
        _scoreText.text = _POINTS.ToString();
        
        _livesCounter = 3;
        foreach (var life in _lives)
        {
            life.SetActive(true);
        }
    }

    public void Score(int score)
    {
        _POINTS += score;

        _scoreText.text = _POINTS.ToString();
    }
}