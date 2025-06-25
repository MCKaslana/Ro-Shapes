using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    //public static PuzzleManager Instance;

    //[SerializeField] private List<RoShape> _shapes = new();
    [SerializeField] Text timerText;
    [SerializeField] Text _scoreBoardText;
    [SerializeField] private GameObject _winScreen;
    private LevelSettings _levelSettings;
    private float _highScore;
    private float _timePassed = 0f;

    private void Start()
    {
        _levelSettings = GameObject.Find("Canvas").GetComponent<LevelSettings>();
        _winScreen.SetActive(false);
        for(int i=0; i< _levelSettings.roShapes.Count; i++)
        {
            _levelSettings.roShapes[i].Init(this, i);
        }
    }

    private void Update()
    {
        CountDownTime();
    }

    private void LoadLevel()
    {
        Time.timeScale = 1;
        _timePassed = 0;
    }

    public void ShapeClicked(int shapeIndex)
    {
        

        _levelSettings.roShapes[shapeIndex].Rotate();
        int connectIndex = shapeIndex + 1;

        if (connectIndex > _levelSettings.roShapes.Count - 1)
        {
            connectIndex = 0;
        }

        Debug.Log("ConnectIndex: " + connectIndex);
        _levelSettings.roShapes[connectIndex].Rotate();

        if (CheckIsEqual())
        {
            _winScreen.SetActive(true);
            _highScore = _timePassed;
            UpdateHighScore();
            Time.timeScale = 0;
            foreach (var shape in _levelSettings.roShapes)
            {
                shape.GetComponent<Button>().enabled = false;
            }
        }
    }

    public void CountDownTime()
    {
        _timePassed += Time.deltaTime;
        timerText.text = "Time Elapsed: " + Mathf.Max(0, _timePassed).ToString("F2") + "s";
    }

    public bool CheckIsEqual()
    {
        for (int i=2; i<_levelSettings.equation.Count; i=i+3)
        {
            int a = _levelSettings.roShapes[_levelSettings.equation[i - 2]].value;
            int b = _levelSettings.roShapes[_levelSettings.equation[i - 1]].value;
            int c = _levelSettings.roShapes[_levelSettings.equation[i]].value;
            Debug.Log($"{a} + {b} = {c}?");
            
            if (a + b != c)
            {
                return false;
            }
        }
        return true;
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

    public void AddEquation()
    {

    }
}
