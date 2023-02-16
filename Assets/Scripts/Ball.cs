using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 10f;

    public float speedIncreaseOnSpeed = 0.5f;

    Rigidbody rigid;

    public AudioClip ballHit;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        rigid = gameObject.GetComponent<Rigidbody>();
        Reset();
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        Vector3 vel = Vector3.down;

        vel.x = Random.Range(-1f, 1f);
        vel.y = Random.Range(-1f, 1f);

        if (Mathf.Abs(vel.x) < 0.4f)
        {
            Reset();
        }

        vel.Normalize();

        vel *= startSpeed;
        rigid.velocity = vel;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 vel = rigid.velocity;

        float speed = vel.magnitude;

        speed += speedIncreaseOnSpeed;

        vel = vel.normalized * speed;

        PlayerControl pc = collision.gameObject.GetComponent<PlayerControl>();

        if (pc != null)
        {
            audioSource.PlayOneShot(ballHit);
            float yDelta = transform.position.y - pc.transform.position.y;
            yDelta = yDelta * 2 / pc.transform.localScale.y;

            vel = new Vector3(1, yDelta, 0);
            
            vel = vel.normalized * speed;

            Score.ScoreIncrease();

            

        }

        AIControl ai = collision.gameObject.GetComponent<AIControl>();

        if (ai != null)
        {
            audioSource.PlayOneShot(ballHit);
            float yDelta = transform.position.y - ai.transform.position.y;
            yDelta = yDelta * 2 / ai.transform.localScale.y;

            vel = new Vector3(-1, yDelta, 0);
            
            vel = vel.normalized * speed;
            

            Score.ScoreIncrease();

            

        }

        

        rigid.velocity = vel;

        

    }

    private void FixedUpdate()
    {
        if (transform.position.x < -16 || transform.position.x > 16)
        {
            Reset();
            Score.Reset();
        }
    }

}
