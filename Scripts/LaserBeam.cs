using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{

    GameObject laserObj;
    Vector2 position, direction;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();

    // Refreshes every Update() to stay in sync with position/orientation of laser pointer.
    public LaserBeam(Vector2 position, Vector2 direction, Material material)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.position = position;
        this.direction = direction;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;

        CastRay(position, direction, laser);
    }

    void CastRay(Vector2 position, Vector2 direction, LineRenderer laser)
    {
        laserIndices.Add(position);

        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 30, 1))
        {
            CheckHit(hit, direction, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int counter = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector2 i in laserIndices)
        {
            laser.SetPosition(counter, i);
            counter++;
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector2 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector2 position = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);

            CastRay(position, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }

}
