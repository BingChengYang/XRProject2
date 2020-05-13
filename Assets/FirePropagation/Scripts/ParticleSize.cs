using UnityEngine;
using System.Collections;

public class ParticleSize : MonoBehaviour {
 
    ParticleSystem[] ps;
    public float psScaleFloat = 99.0f;
    void Start(){
        foreach (var item in transform.GetComponentsInChildren<ParticleSystem>())
        {
            
            var main = item.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            item.transform.localScale = new Vector3(psScaleFloat, psScaleFloat, psScaleFloat);
        }
    }
 
	void Update () {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     foreach (var item in transform.GetComponentsInChildren<ParticleSystem>())
        //     {
        //         var main = item.main;
        //         main.scalingMode = ParticleSystemScalingMode.Local;
        //         item.transform.localScale = new Vector3(psScaleFloat, psScaleFloat, psScaleFloat);
        //     }
        // }
	}

    public void MinFire(float amount){
        psScaleFloat -= amount;
        Debug.Log(psScaleFloat);
    }

}
