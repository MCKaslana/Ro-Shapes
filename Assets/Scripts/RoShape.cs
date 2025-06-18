using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class RoShape : MonoBehaviour
{
    public int value { get => _edgeNumbers[index];}
    [SerializeField] private int[] _edgeNumbers;

    [SerializeField] int index = 0;
    [SerializeField] int step = 1;
    [SerializeField] int edges = 3;
    [SerializeField] RoShape connectedShape;

    private void OnEnable()
    {
        setup();
    }

    void setup()
    {
        float startRotateAngle = 360 / edges * index;
        transform.Rotate(new Vector3(0, 0, -startRotateAngle));
    }

    public void Rotate()
    {
        float rotateAngle = 360 / edges * step;
        transform.Rotate(new Vector3(0, 0, -rotateAngle));
        index += step;
        if (index > edges - 1)
        {
            index -= edges;
        }
        Debug.Log("The index is " + index.ToString());
        connectedShape.RotateByOther();
    }

    public void RotateByOther()
    {
        float rotateAngle = 360 / edges * step;
        Debug.Log("Rotate angle is: " + rotateAngle.ToString());
        transform.Rotate(new Vector3(0, 0, -rotateAngle));
        index += step;
        if (index > edges - 1)
        {
            index -= edges;
        }
        Debug.Log("The index is " + index.ToString());
    }
}
