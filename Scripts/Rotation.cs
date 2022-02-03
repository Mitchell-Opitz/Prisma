using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    private float sensitivity;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;
    private bool isRotating;

    void Start()
    {
        sensitivity = 0.4f;
        rotation = Vector2.zero;
    }

    void Update()
    {
        if (isRotating)
        {
            mouseOffset = (Input.mousePosition - mouseReference);
            rotation.z = -(mouseOffset.x + mouseOffset.y) * sensitivity;
            transform.Rotate(rotation);
            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        isRotating = true;
        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }
}