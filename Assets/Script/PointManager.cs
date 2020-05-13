using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    Fire1 fire = new Fire1();
    [SerializeField]
    GameObject success;
    [SerializeField]
    GameObject fail;
    [SerializeField]
    int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        success.SetActive(false);
        fail.SetActive(false);
        totalScore = fire.ReturnScore();
        ShowResult();
    }
    public void ShowResult()
    {
        if(totalScore > 10)
        {
            success.SetActive(true);
        }
        else
        {
            fail.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
