using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public GameObject[] characters;
    public int selectedCharacter = 0;
    public bool rightCharacter = false;

    public GameObject rightCharacters;


    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        characters[(selectedCharacter + 1) % characters.Length].SetActive(false);
    }

    public void PrevCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        characters[selectedCharacter].SetActive(true);
    }

    public void Start()
    {
        if (!rightCharacter)
        {
            PlayerPrefs.SetInt("selectedLeftCharacter", selectedCharacter);
            rightCharacters.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("selectedRightCharacter", selectedCharacter);
            SceneManager.LoadScene(1);
        }
    }

}
