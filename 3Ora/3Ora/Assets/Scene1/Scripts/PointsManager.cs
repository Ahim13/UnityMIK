using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    
    [SerializeField] private Text _pointText;

    public float Score
    {
        get { return _score; }
    }

    private float _score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if(Instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);

        _pointText.text = _score.ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
        _pointText.text = _score.ToString();
    }
}
