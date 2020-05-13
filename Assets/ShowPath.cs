using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class ShowPath : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // var filePath = Application.persistentDataPath + "/Screenshot.png";
        // Texture2D test = LoadPNG(filePath);
        // if(test == null){
        //     txt.GetComponent<UnityEngine.UI.Text>().text = "we don't load the PNG";
        // }else txt.GetComponent<UnityEngine.UI.Text>().text = Application.persistentDataPath;
        
    }
     public static Texture2D LoadPNG(string filePath) {
 
     Texture2D tex = null;
     byte[] fileData;
 
     if (System.IO.File.Exists(filePath))     {
         fileData = File.ReadAllBytes(filePath);
         tex = new Texture2D(2, 2);
         tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
     }
     return tex;
 }
}
