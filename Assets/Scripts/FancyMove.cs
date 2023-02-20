using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyMove : MonoBehaviour
{






    public float time = Mathf.Infinity;
    public float duration = 1;



    void Start()
    {
    }

    void Update()
    {
        SpecialMove();

    }

    public void Swing()
    {
        time = 0;
        StartCoroutine(SpecialMove());
    }



    virtual public IEnumerator SpecialMove()
    {
        yield return null;
    }
}
