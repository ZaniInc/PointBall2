using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    public GameObject panel;
    public float power;
    public GameObject MainBall;

    private Renderer render;
    
    public Collider ball;
    Ray ray;
    public Trajectory trajectoryy;
    private Rigidbody _rb;
  
    public Transform StartPos;
   
    public float RayDist = 10;
    public Camera _camera;
    
    RaycastHit hit;
    private Vector3 speed;

    Vector3 mouseinworld;
    public Transform ball_pos;

   



    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;

        
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Physics.Raycast(ray , out hit))
        {
            Debug.Log("HIT");
           
        }
        

        mouseinworld = ray.GetPoint(10);
        speed = (mouseinworld - transform.position) * power;
        //transform.rotation = Quaternion.LookRotation(ray.direction);

        ray = _camera.ScreenPointToRay(Input.mousePosition);
        trajectoryy.showtrajectory(transform.position, speed);

        if (ball_pos.position.y <= 28.0f)
        {
            Destroy(gameObject);
            panel.SetActive(true);
            
        }

    }

    private void Update()
    {
        Shot();
       
    }

    void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.AddForce(speed , ForceMode.VelocityChange);
            
        }    

    }

    private void OnTriggerEnter(Collider other)
    {
        if (ball)
        {
            GameObject MainBall2 = Instantiate(MainBall, StartPos.position, Quaternion.identity);
            trajectoryy.line.enabled = true;
            Destroy(gameObject);

            
            
        }
    }


}
