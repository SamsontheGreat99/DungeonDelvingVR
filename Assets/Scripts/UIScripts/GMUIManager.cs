using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This manages the pages of the GMUI

public class GMUIManager : MonoBehaviour
{
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject thirdScreen;
    public GameObject page1Button;
    public GameObject page2Button;
    public GameObject page2BackButton;
    public GameObject page3Button;

    private void Awake()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void Page1()
    {
        firstScreen.SetActive(true);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(false);
        page1Button.SetActive(false);
        page2Button.SetActive(true);
        page2BackButton.SetActive(false);
        page3Button.SetActive(false);

    }
    public void Page2()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
        thirdScreen.SetActive(false);
        page1Button.SetActive(true);
        page2Button.SetActive(false);
        page2BackButton.SetActive(false);
        page3Button.SetActive(true);
    }
    public void Page3()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(true);
        page1Button.SetActive(false);
        page2Button.SetActive(false);
        page2BackButton.SetActive(true);
        page3Button.SetActive(false);
    }
}
