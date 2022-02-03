using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool IsPressed = false;
    private Rigidbody rb;
    private Ray ray = new Ray();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsPressed == true)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }


    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;

        StartCoroutine(fly());
    }

    IEnumerator fly()
    {
        yield return new WaitForSeconds(0.1f);

        //gameObject.GetComponent<ConfigurableJoint>().targetVelocity = 0;
        this.enabled = false;

    }
}
