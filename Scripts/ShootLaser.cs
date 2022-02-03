using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{

    public Material material;
    public Color color;
    public string name;
    LaserBeam beam;

    void Update()
    {
        Destroy(GameObject.Find(name));
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.up, material, color, name);
    }
}
