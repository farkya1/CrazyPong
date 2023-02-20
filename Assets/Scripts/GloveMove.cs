using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMove : FancyMove
{
    Vector3 startPos;
    public Vector3 endPos;

    public override IEnumerator SpecialMove()
    {

        startPos = transform.position;

        while (time < duration / 2)
        {
            float u = (2*time) / duration;
            u = Mathf.Pow(u, 2);
            u = Mathf.Clamp01(u);
            float newX = Mathf.Lerp(startPos.x, endPos.x, u);

            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = newPosition;
            time += Time.deltaTime;
            yield return null;

        }

        Vector3 endPosition = new Vector3(endPos.x, transform.position.y, transform.position.z);


        transform.position = endPosition;

        time = 0f;

        while (time < duration )
        {
            float u = (time) / duration;
            u = Mathf.Pow(u, 2);
            u = Mathf.Clamp01(u);

            float newX = Mathf.Lerp(endPos.x, startPos.x, u);

            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = newPosition;
            time += Time.deltaTime;
            yield return null;
        }
        

        Vector3 startPosition = new Vector3(startPos.x, transform.position.y, transform.position.z);

        transform.position = startPosition;
        
    }
}
