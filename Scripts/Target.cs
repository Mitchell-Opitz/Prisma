using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public List<GameObject> Doors;

    public void Activate()
    {
        // Convert Target to Barrier
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.black;
        this.gameObject.tag = "Untagged";

        // Trigger block removal
        for(int i = Doors.Count-1; i >=0; i--)
        {
            Destroy(Doors[i].gameObject);
        }

        // Remove Target component
        Destroy(this);
    }
}
