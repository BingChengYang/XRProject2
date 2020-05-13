using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float timeToLife;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ("TimeStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator TimeStart()
	{
        yield return new WaitForSeconds(timeToLife);
        Destroy(gameObject);
        //Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
    }
}
