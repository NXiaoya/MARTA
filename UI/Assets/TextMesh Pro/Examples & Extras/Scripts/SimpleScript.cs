using UnityEngine;

public class RotateModels : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the empty GameObject and its child model around the midpoint
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}