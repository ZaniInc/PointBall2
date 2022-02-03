using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public Transform Ball_Pos;
    public float power = 10;
    private Rigidbody rb;
    public Collider Point;
    Ray ray ;

    private Vector3 start_Pos;

    

    public Trajectory trajectory;



    // Start is called before the first frame update
    void Start()
    {
        //Ball_Pos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
       
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 10;
        Vector3 mouseinworld = ray.GetPoint(enter);
        Vector3 speed = (mouseinworld - transform.position) * power;
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce( start_Pos + speed * Time.time + Physics.gravity * Time.time * Time.time / 2f, ForceMode.VelocityChange);
        }

        Debug.DrawRay(Ball_Pos.position, Input.mousePosition, Color.yellow);
        trajectory.showtrajectory(transform.position, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Point)
        {
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            Ball_Pos.position = new Vector3(0, 9, Point.transform.position.z + 8);

            Debug.Log("clos");

            
        }
    }
}
