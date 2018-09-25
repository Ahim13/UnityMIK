using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private BallController _ballController;
    [SerializeField] private TextMeshProUGUI _player1ScoreText;
    [SerializeField] private TextMeshProUGUI _player2ScoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    private static int _p1Point = 0;
    private static int _p2Point = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void ResetGame()
    {
        _p1Point = 0;
        _p2Point = 0;
        NewRound();
    }

    private void Update()
    {
        if (_p1Point == 3 || _p2Point == 3)
        {
            EndGame();
        }
        _player1ScoreText.text = _p1Point.ToString();
        _player2ScoreText.text = _p2Point.ToString();
    }

    private void EndGame()
    {
        _ballController.ResetBall();
        StartCoroutine(ShowGameOver());
    }

    private IEnumerator ShowGameOver()
    {
        _gameOverText.enabled = true;

        yield return new WaitForSeconds(2);

        _gameOverText.enabled = false;
    }


    public void Score(Side side)
    {
        switch (side)
        {
            case Side.Right:
                _p1Point++;
                break;
            case Side.Left:
                _p2Point++;
                break;
        }

        NewRound();
    }
    
    public void NewRound()
    {
        _ballController.ResetBall();
        StartCoroutine(StartGame(1));
    }
    
    private IEnumerator StartGame(float time)
    {
        yield return new WaitForSeconds(time);
        _ballController.FireBall();
    }
}
