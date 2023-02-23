using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BernieMove : FancyMove
{
    public Quaternion startRotate = Quaternion.Euler(0, 0, 0);
    public Quaternion endRotate = Quaternion.Euler(0, 0, -90);

    public override IEnumerator SpecialMove()
    {


        while (time < duration/6)
        {
            float u = time*6 / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(startRotate,endRotate, u);
            time += Time.deltaTime;
            yield return null;
        }


        transform.rotation = endRotate;
        GameObject freshParticles = Instantiate(particles, transform.position, Quaternion.identity);

        freshParticles.transform.parent = gameObject.transform.parent;
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
        Destroy(freshParticles,2);
    }
}
