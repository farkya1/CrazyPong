using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyMove : MonoBehaviour
{

    public Quaternion startRotate = Quaternion.Euler(0, 0, 0);
    public Quaternion endRotate = Quaternion.Euler(0, -180, 0);

    public bool rotate = false;


    public float startPos;
    public float endPos;

    public bool position = false;


    public float time = Mathf.Infinity;
    public float duration = 1;

    private Vector3 pos;


    void Start()
    {
        pos = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        float u = time / duration;

        if (rotate)
        {
           

            u = Mathf.Clamp(u, 0, 1);


            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(startRotate, endRotate, u);

            time += Time.deltaTime;
        }
        else if (position)
        {


            u = Mathf.Clamp(u, 0, 1);


            u = Mathf.Pow(u, 2);

            pos.x = Mathf.Lerp(startPos, endPos, u);

            time += Time.deltaTime;
        }

    }

    public void Swing()
    {
        time = 0;
    }
}
