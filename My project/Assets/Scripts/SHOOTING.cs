using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOOTING : MonoBehaviour
{
    public Transform SpawnTransform;
    public float power;
    private Transform TargetTransform;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    private Rigidbody _rb;
    Ray ray;
    RaycastHit hit;
    Camera cameraa;


    // Start is called before the first frame update
    void Start()
    {
        cameraa = Camera.main;
        _rb = GetComponent<Rigidbody>();
        ray = cameraa.ScreenPointToRay(Input.mousePosition);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnTransform.eulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Shott();
        }
        
    }

    public void Shott()
    {
        if (Physics.Raycast(ray , out RaycastHit hit))
        {
            Debug.Log("1");
            TargetTransform.position = hit.transform.position;
            
        }


        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, ray.direction);
        

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AnglesInRad = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AnglesInRad) * x) * Mathf.Pow(Mathf.Cos(AnglesInRad), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        _rb.AddForce(hit.transform.position * v , ForceMode.Impulse);

    }
}
