using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Collider ball;
    public GameObject BOOM;
    public AudioSource babax;
    public Transform spawnboom;
    public Text Score;
    private int count;
   
   
   

    // Start is called before the first frame update
    void Start()
    {
        Score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider collision)
    {
       
        if (true)
        {
            count++;
            Score.text = "" + count;

            babax.Play();
            GameObject newboom = Instantiate(BOOM, spawnboom.position, Quaternion.identity);
            Destroy(newboom, 1f);
            
        }
    }
   

}
