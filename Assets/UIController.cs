using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject DetectUI;
    bool DetectUIisOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        DetectUIisOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectOnClick()
    {
        if (DetectUIisOpen)
        {
            DetectUIisOpen = false;
            DetectUI.SetActive(false);
        }
        else
        {
            DetectUIisOpen = true;
            DetectUI.SetActive(true);
        }
    }
}
