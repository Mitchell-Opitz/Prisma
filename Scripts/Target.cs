using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{

    public List<GameObject> Doors;
    public AudioSource targetSound;
    public Material material;
    public Color color;

    void Start()
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = color;
    }
    public void CheckColor(Color laserColor)
    {
        if (laserColor[0] == color[0] &
            laserColor[1] == color[1] &
            laserColor[2] == color[2])
        {
            Activate();
        }
    }

    void Activate()
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
        targetSound = GetComponent<AudioSource>();
        targetSound.Play(0);
    }
}
