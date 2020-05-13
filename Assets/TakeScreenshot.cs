using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
    //GameObject blink;
    UIController uicon;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean shotAction;
    WaterController waterController;
    int count =0;
    private void Start()
    {
        uicon = gameObject.GetComponent<UIController>();
        waterController = GameObject.Find("WaterBar").GetComponent<WaterController>();
    }

    void Update()
    {
        if (shotAction.GetStateDown(handType)){
            Debug.Log("take pic!");
            StartCoroutine ("CaptureIt");
            // add amount to bottle
            if(count ==0) waterController.AddWater(8,0);
            else if(count == 1) waterController.AddWater(10,1);
            if(count == 2) waterController.AddWater(12,2);
            count = (count + 1) % 3;
        }
  
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot.png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForSeconds(0.5f);
        //Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
    }

}
