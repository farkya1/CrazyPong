using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    public GameObject[] leftCharacters;
    public Transform leftSpawnPoint;

    public GameObject[] rightCharacters;
    public Transform rightSpawnPoint;

    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        int leftCharacter = PlayerPrefs.GetInt("selectedLeftCharacter");
        GameObject leftChar = leftCharacters[leftCharacter];
        Instantiate(leftChar, leftSpawnPoint.position, Quaternion.identity);

        int rightCharacter = PlayerPrefs.GetInt("selectedRightCharacter");
        GameObject rightChar = rightCharacters[rightCharacter];
        GameObject clone = Instantiate(rightChar, rightSpawnPoint.position, Quaternion.Euler(0,180,0));
        AIControl aiControl = clone.GetComponent<AIControl>();
        aiControl.SetBall(ref ball);
        

    }

}
