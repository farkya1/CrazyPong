using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeBall : MonoBehaviour
{
    public Paddle paddle;




    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            paddle.Swing();
        }
        
        
    }
}
