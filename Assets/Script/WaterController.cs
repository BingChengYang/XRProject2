using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WaterController : MonoBehaviour
{
    [SerializeField]
    public static int[] remain = new int[3];
    [SerializeField]
    GameObject[] waterDot;
    
    public SteamVR_Action_Boolean switchType;
    public SteamVR_Input_Sources handType;

    [SerializeField]
    int index;  // this represent the type of water

    [SerializeField]
    GameObject[] weapon;


    // Start is called before the first frame update
    void Start()
    {
        remain[0] = 5;
        remain[1] = 3;
        remain[2] = 2;
        index = 0;

        weapon[0].SetActive(true);
        weapon[1].SetActive(false);
        weapon[2].SetActive(false);

        foreach (GameObject obj in waterDot)
        {
            obj.SetActive(false);
        }
    }
    public bool GetWater()
    {
        if (remain[index] > 0) return true;
        return false;
    }
    public void AddWater(int amount,int i)
    {
        remain[i] += amount;
    }
    public void MinusWater(int amount)
    {
        remain[index] -= amount;
    }
    public void SwitchWaterType()
    {
        weapon[index].SetActive(false);
        index =  (index+1)%3;
        weapon[index].SetActive(true);

    }
    public int GetType(){
        return index;
    }
    // Update is called once per frame
    void Update()
    {
        if(switchType.GetStateDown(handType))SwitchWaterType();
        if (remain[index] > 20) remain[index] = 20;
        int i = 0;
        for (; i < remain[index]; i++)
        {
            waterDot[i].SetActive(true);
        }
        for (; i < 20; i++)
        {
            waterDot[i].SetActive(false);
        }
    }
}
