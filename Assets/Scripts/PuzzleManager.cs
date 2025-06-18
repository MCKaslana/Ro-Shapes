using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<RoShape> _shapes = new();
    [SerializeField] Text timerText;
    private float _timePassed = 0f;

    private void Update()
    {
        if (CheckIsEqual())
        {
            Debug.Log("Time:" +  _timePassed);
        }
        else
        {
            CountDownTime();
        }
    }

    public void CountDownTime()
    {
        _timePassed += Time.deltaTime;
        timerText.text = "Time Elapsed: " + Mathf.Max(0, _timePassed).ToString("F2");
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
}
