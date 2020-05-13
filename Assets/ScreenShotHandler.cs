using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenShotHandler : MonoBehaviour
{

    private static ScreenShotHandler instance;
    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;



    private void Awake()
    {
        instance = this;
        myCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //myCamera = gameObject.GetComponent<Camera>();
    }
    void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }
    void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }
    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        OnPostRender();
    }
    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            Debug.Log("Try To Capture");
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/shot.png", byteArray);
            Debug.Log("Save");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }
    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }
    public void TakeScreenshot_Static()
    {
        Debug.Log("Click the button");
        instance.TakeScreenshot(Screen.width, Screen.height);
        //ScreenCapture.CaptureScreenshot("SomeLevel");
    }
}
