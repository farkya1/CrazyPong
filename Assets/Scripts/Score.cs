using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    static int scoreNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreNum.ToString();
    }

    private void Update()
    {
        scoreText.text = scoreNum.ToString();
    }


    static public void ScoreIncrease()
    {
        scoreNum += 1;
    }

    static public void Reset()
    {
        scoreNum = 0;
    }
}
