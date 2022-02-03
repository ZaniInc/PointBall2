using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [HideInInspector]public LineRenderer line;
    Vector3[] points;
    float time;



    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line.enabled = false;
        }
    }

    public void showtrajectory(Vector3 start_pos,Vector3 speed)
    {

      

        points = new Vector3[100];
        line.positionCount = points.Length;

       

        for (int i = 0; i < points.Length; i++)
        {

            time = i * 0.1f;

            points[i] = start_pos + speed * time + (Physics.gravity * (time * time) / 2f) ;

            if (points[i].y < 0)
            {
                line.positionCount = i;
                break;
            }

        }

        line.SetPositions(points);

    }
}
