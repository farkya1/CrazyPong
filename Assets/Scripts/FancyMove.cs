using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyMove : MonoBehaviour
{


    public AudioClip[] clips;

    public AudioSource source;

    public GameObject particles;

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

    public void PlaySound()
    {
        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }


    virtual public IEnumerator SpecialMove()
    {
        yield return null;
    }
}
