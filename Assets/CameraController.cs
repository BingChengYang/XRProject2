using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public WebCamTexture mCamera = null;
    [SerializeField]
    public GameObject plane;

    // Use this for initialization
    void Start()
    {
        plane = GameObject.FindWithTag("Player");

        mCamera = new WebCamTexture();
        plane.GetComponent<Renderer>().material.mainTexture = mCamera;
        mCamera.Play();
        if (mCamera == null) Debug.Log("Why??");

    }

    // Update is called once per frame
    void Update()
    {

    }
}