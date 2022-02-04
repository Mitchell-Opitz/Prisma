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
    public LaserBeam(Vector2 position, Vector2 direction, Material material, Color color, string name)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = name;
        this.position = position;
        this.direction = direction;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.15f;
        this.laser.endWidth = 0.15f;
        this.laser.material = material;
        this.laser.startColor = color;
        this.laser.endColor = color;

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
        else if(hitInfo.collider.gameObject.tag == "Target")
        {
            Target target = (Target) hitInfo.collider.gameObject.GetComponent(typeof(Target));
            target.Activate();
            AddLaserIndex(hitInfo);
        }
        else if(hitInfo.collider.gameObject.tag == "Prism")
        {
            Prism prism = (Prism)hitInfo.collider.gameObject.GetComponent(typeof(Prism));
            prism.Activate();
            AddLaserIndex(hitInfo);
        }    
        else
        {
            AddLaserIndex(hitInfo);
        }
    }

    void AddLaserIndex(RaycastHit hitInfo)
    {
        // Debug.Log(hitInfo.collider.gameObject.name + " triggered.");
        laserIndices.Add(hitInfo.point);
        UpdateLaser();
    }

}
