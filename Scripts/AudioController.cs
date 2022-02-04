using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public List<GameObject> Targets;
    private bool targetRemains;
    private bool loopedStopped = false;
    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        if (!loopedStopped)
        {
            targetRemains = false;
            // Trigger block removal
            for (int i = Targets.Count - 1; i >= 0; i--)
            {
                if (Targets[i].tag == "Target")
                {
                    targetRemains = true;
                }
            }

            if (!targetRemains)
            {
                music.loop = false;
                loopedStopped = true;
            }
        }
    }
}
