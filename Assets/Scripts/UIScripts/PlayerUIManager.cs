using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the pages for the player UI, pretty straightforward

public class PlayerUIManager : MonoBehaviour
{
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject thirdScreen;

    public GameObject Page1Button;
    public GameObject Page2Button;
    public GameObject Page2BackButton;
    public GameObject Page3Button;

    private void Awake()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void DebugHEH()
    {
        Debug.Log("pressed");
    }
    public void NextButton()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
    }
    public void BackButton()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
    }
    public void Page1()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(false);

        Page1Button.SetActive(false);
        Page2Button.SetActive(true);
        Page2BackButton.SetActive(false);
        Page3Button.SetActive(false);
    }
    public void Page2()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
        thirdScreen.SetActive(false);

        Page1Button.SetActive(true);
        Page2Button.SetActive(false);
        Page2BackButton.SetActive(false);
        Page3Button.SetActive(true);
    }
    public void Page3()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(true);

        Page1Button.SetActive(false);
        Page2Button.SetActive(false);
        Page2BackButton.SetActive(true);
        Page3Button.SetActive(false);
    }
}
