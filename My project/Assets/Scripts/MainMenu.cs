using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Button Startt;
    public static bool Pause;
    public GameObject pausemenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Suka()
    {
            pausemenu.SetActive(false);
        
        
        
    }
}
