using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4

    public WaterController WaterDot;
    public GameObject waterObj;

    public float biasNum;

    
    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
        WaterDot = GameObject.Find("WaterBar").GetComponent<WaterController>();
    }

    // Update is called once per frame
    void Update()
    {
     
            RaycastHit hit;

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 500))
            {

                hitPoint = hit.point;
                ShowLaser(hit);

                if( WaterDot.GetWater() && grabAction.GetStateDown(handType) ){
                    Quaternion rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
                    Vector3 bias = new Vector3(0,biasNum,0);
                    Vector3 position = (controllerPose.transform.position + hit.point)/2 + bias;
                    GameObject.Instantiate(waterObj , position, rotation);
                    WaterDot.MinusWater(1);   
                                    // this only click once for button
                    if(hit.collider.CompareTag("fire") && grabAction.GetStateDown(handType) ){
                    
                        Debug.Log("hit!!!!");
                        GameObject g = hit.transform.gameObject;
                        Fire1 f;
                        f = g.GetComponent<Fire1>();
                        f.click();
                        
                    }
                }




                //this is Long Press for controller button

                // if(hit.collider.CompareTag("fire") && grabAction.GetState(handType) ){
                  
                //     Debug.Log("hit!!!!");
                //     GameObject g = hit.transform.gameObject;
                //     Fire1 f;
                //     f = g.GetComponent<Fire1>();
                //     f.click();
                      
                // }
            }
            else // 3
            {
                laser.SetActive(false);
            }
            
    }
    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
}
