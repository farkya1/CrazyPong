using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : FancyMove
{
    public Quaternion startRotate;
    public Quaternion endRotate = Quaternion.Euler(0, -180, 0);

    public override IEnumerator SpecialMove()
    {

        Quaternion startRotation = transform.rotation;


        transform.rotation = endRotate;
        yield return null;

        time = 0f;

        while (time < duration)
        {
            float u = time / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(endRotate, startRotate, u);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotate;
    }
}
