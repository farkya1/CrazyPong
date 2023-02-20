using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : FancyMove
{
    public Vector3 startScale;
    public Vector3 endScale;

    public override IEnumerator SpecialMove()
    {
        startScale = transform.localScale;

        while (time < duration)
        {
            float u = time / duration;
            u = Mathf.Pow(u, 2);
            transform.localScale = Vector3.Lerp(startScale, endScale, u);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;

        time = 0f;

        while (time < duration)
        {
            float u = time / duration;
            u = Mathf.Pow(u, 2);
            transform.localScale = Vector3.Lerp(endScale, startScale, u);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
    }


}
