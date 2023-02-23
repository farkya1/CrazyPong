using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public GameObject ball;


    public float yLimit = 7.25f;
    public float speed = 22;

    Vector3 startPos;


    Vector2 forward = Vector2.left;

    private void Start()
    {
        startPos = transform.position;
    }

    public void SetBall(ref GameObject ballGO)
    {
        ball = ballGO;
    }

    private void Update()
    {



        float targetYPosition = GetNewYPosition();

        transform.position = new Vector3(transform.position.x, targetYPosition, transform.position.z);

    }

    private float GetNewYPosition()
    {
        float output = transform.position.y;

        if (BallIncoming())
        {
            output = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, speed * Time.deltaTime);
        }
        output = Mathf.Clamp(output, -yLimit, yLimit);
        return output;
    }

    private bool BallIncoming()
    {
        float dotProduct = Vector2.Dot(ball.GetComponent<Rigidbody>().velocity, forward);

        return dotProduct < 0f;
    }
}
