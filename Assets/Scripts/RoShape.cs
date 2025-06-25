using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class RoShape : MonoBehaviour
{
    public int value { get => _edgeNumbers[currentNumberIndex];}
    [SerializeField] private int[] _edgeNumbers;

    [SerializeField] int currentNumberIndex = 0;
    [SerializeField] int step = 1;
    [SerializeField] int edges = 3;
    int index;
    PuzzleManager manager;

    private void OnEnable()
    {
        setup();
    }

    void setup()
    {
        float startRotateAngle = 360 / edges * currentNumberIndex;
        transform.Rotate(new Vector3(0, 0, -startRotateAngle));
    }

    public void Rotate()
    {
        float rotateAngle = 360 / edges * step;
        transform.Rotate(new Vector3(0, 0, -rotateAngle));
        currentNumberIndex += step;
        if (currentNumberIndex > edges - 1)
        {
            currentNumberIndex -= edges;
        }
        Debug.Log("The currentNumberIndex is " + currentNumberIndex.ToString());
        
    }

    public void Clicked()
    {
        manager.ShapeClicked(index);
    }

    public void Init(PuzzleManager manager, int index)
    { 
        this.index = index; 
        this.manager = manager;
    }
}
