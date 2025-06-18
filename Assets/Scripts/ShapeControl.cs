using UnityEngine;

public class ShapeControl : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateAmount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(_rotateAmount);
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(-_rotateAmount);
        }
    }
}
