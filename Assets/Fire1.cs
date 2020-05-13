using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    public static int score = 0;
    WaterController waterDot;
    // Start is called before the first frame update
    public int hp = 3;
    void Start()
    {
        waterDot = GameObject.Find("WaterBar").GetComponent<WaterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ReturnScore()
    {
        return score;
    }
    public void click()
    {
        Debug.Log(hp);
        
        
        ParticleSize p;
        p = gameObject.GetComponent<ParticleSize>();
        if(waterDot.GetType() == 0){
            p.MinFire(33.0f);
            score = score + 1;
            hp = hp - 1;
        }
        else if(waterDot.GetType() == 1){
            p.MinFire(49.0f);
            score = score + 2;
            hp = hp - 2;
        }
        else if(waterDot.GetType() == 2){
            p.MinFire(99.0f);
            score = score + 3;
            hp = hp -3;
        }


        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
