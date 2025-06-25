using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [SerializeField] private List<RoShape> _shapes = new();
    [SerializeField] Text timerText;
    [SerializeField] Text _scoreBoardText;
    [SerializeField] private GameObject _winScreen;

    private float _highScore;
    private float _timePassed = 0f;

    private void Start()
    {
        _winScreen.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Update()
    {
        if (CheckIsEqual())
        {
            _winScreen.SetActive(true);
            _highScore = _timePassed;
            UpdateHighScore();
        }
        else
        {
            CountDownTime();
        }
    }

    public void CountDownTime()
    {
        _timePassed += Time.deltaTime;
        timerText.text = "Time Elapsed: " + Mathf.Max(0, _timePassed).ToString("F2") + "s";
    }

    public bool CheckIsEqual()
    {
        Debug.Log($"check {_shapes[0].value} + {_shapes[1].value} and {_shapes[2].value}");
        if (_shapes[0].value + _shapes[1].value == _shapes[2].value)
        {
            return true;
        }

        return false;
    }

    public void ResetGame()
    {
        _timePassed = 0f;
    }

    public void UpdateHighScore()
    {
        _scoreBoardText.text =
            "Best Time:" + "\n" +
            _highScore.ToString("F2") + " Seconds!";
    }
}
