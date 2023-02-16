using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{





    Quaternion rotationY0 = Quaternion.Euler(0, 0, 0);
    Quaternion rotationYNegative180 = Quaternion.Euler(0, -180, 0);

    public float time = Mathf.Infinity;
    public float duration = 1;


    void Start()
    {
    }

    void Update()
    {

        float u = time / duration;


        u = Mathf.Clamp(u, 0, 1);
        

        u = Mathf.Pow(u,2);

        transform.rotation = Quaternion.Lerp(rotationY0, rotationYNegative180, u);

        time += Time.deltaTime;
    }

    public void Swing()
    {
        time = 0;
    }
}
