using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_fire : MonoBehaviour
{
    public GameObject ob;
    public float Ins_Time = 1000;
    // Start is called before the first frame update
    void Start()
    {
     
        InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);
        //Ins_Objs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ins_Objs()
    {

    var x = Random.Range(150f , 850f);
    var y = Random.Range(150f , 450f);
    GameObject g = Instantiate(ob, new Vector3(x,y,0),  new Quaternion(0,0,0,0)) ;
    g.transform.SetParent(GameObject.Find("Canvas").transform);

    //Instantiate實例化(要生成的物件, 物件位置, 物件旋轉值);

    }
}
