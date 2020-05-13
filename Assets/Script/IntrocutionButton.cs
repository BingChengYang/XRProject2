using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Valve.VR;

public class IntrocutionButton : MonoBehaviour
{
    [SerializeField]
    GameObject first;
    [SerializeField]
    GameObject second;
    [SerializeField]
    GameObject third;
    [SerializeField]
    GameObject forth;
    [SerializeField]
    GameObject fifth;
    int index;
    [SerializeField]
    GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        AllDis();
        first.SetActive(true);
    }

    public void NextOnClick()
    {
        index++;
        GameObject.Instantiate(sound , gameObject.transform.position, Quaternion.identity);
        AllDis();
        if(index == 0) first.SetActive(true);
        else if (index == 1) second.SetActive(true);
        else if (index == 2) third.SetActive(true);
        else if (index == 3) forth.SetActive(true);
        else if (index == 4) fifth.SetActive(true);
        else if (index == 5) SceneManager.LoadScene("S");
    }

    private void AllDis()
    {
        first.SetActive(false);
        second.SetActive(false);
        third.SetActive(false);
        forth.SetActive(false);
        fifth.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NextOnClick();
            print("space arrow key is held down");
        }
    }
}
