using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public GameObject ball;

    [Header("Inscribed")]

    public float yLimit = 7.5f;

    Vector3 startPos;

    float ballYPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {


        Vector3 pos = startPos;

        pos.y = ball.GetComponent<Transform>().position.y;

        pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);

        transform.position = pos;

    }
}
