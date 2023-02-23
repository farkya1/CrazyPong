using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornMove : FancyMove
{

    public Quaternion startRotate = Quaternion.Euler(0, 0, 0);
    public Quaternion middleRotate = Quaternion.Euler(0, 0, -45);
    public Quaternion endRotate = Quaternion.Euler(0, 0, 45);

    public override IEnumerator SpecialMove()
    {


        while (time < duration / 4)
        {
            float u = time * 4 / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(startRotate, middleRotate, u);
            time += Time.deltaTime;
            yield return null;
        }


        transform.rotation = middleRotate;
        GameObject freshParticles = Instantiate(particles, transform.position, Quaternion.identity);

        freshParticles.transform.parent = gameObject.transform.parent;
        yield return null;

        time = 0f;

        while (time < duration /4)
        {
            float u = time *4 / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(middleRotate, endRotate, u);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotate;
        time = 0f;

        while (time < duration / 4)
        {
            float u = time * 4 / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(endRotate, middleRotate, u);
            time += Time.deltaTime;
            yield return null;
        }


        transform.rotation = middleRotate;

        yield return null;

        time = 0f;

        while (time < duration / 4)
        {
            float u = time * 4 / duration;

            u = Mathf.Pow(u, 2);

            transform.rotation = Quaternion.Lerp(middleRotate, startRotate, u);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotate;
        Destroy(freshParticles, 2);
    }
}
