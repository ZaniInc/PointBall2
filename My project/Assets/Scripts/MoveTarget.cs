using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float speed;
    Vector3 start_Pos;
    
    public Transform [] ponts = new Transform [3];
    private int PosX;
    
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        PosX = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
       
        target = ponts[PosX];


        transform.position = Vector3.MoveTowards(transform.position ,target.position , step );

        if (transform.position == target.position)
        {
            PosX++;

            if (PosX >= ponts.Length)
            {
                PosX = 0;
            }

        }

    }
}
