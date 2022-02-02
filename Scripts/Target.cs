using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public void Testing()
    {
        Debug.Log("Target hit!");
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.blue;
    }
}
