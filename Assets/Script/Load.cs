using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load : MonoBehaviour
{
    public string sceneName = "";
    // Start is called before the first frame update
    public void loadscene(string name){
        SceneManager.LoadScene(name);
        Debug.Log(sceneName); 
    }
}
