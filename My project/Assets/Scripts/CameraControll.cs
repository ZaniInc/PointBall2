using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform ball;
    public float speed;
    public float Offsetx;
    public float Offsety;
    public float Offsetz;
    
    private Vector3 TargetPos;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TargetPos = ball.position;
        TargetPos.x = Offsetx;
        TargetPos.y = Offsety;
        TargetPos.z = ball.position.z - Offsetz;
        transform.position = Vector3.Lerp(transform.position, TargetPos, speed * Time.deltaTime);
    }
}
