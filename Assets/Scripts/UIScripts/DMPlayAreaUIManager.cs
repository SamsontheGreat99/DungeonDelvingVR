using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the script that manages the multipage UI for the Game Master in his environments

public class DMPlayAreaUIManager : MonoBehaviour
{
    public GameObject spawnEnemiesTab;
    public GameObject viewEnemiesTab;
    public GameObject musicOptionsTab;
    public GameObject musicSettingsTab;
    public GameObject rollInitiativeTab;
    public GameObject viewPlayerStatsTab;

    public GameObject goblinSheet;
    public GameObject VampireSheet;

    public GameObject[] tabsLeft;
    public GameObject[] tabsRight;
    public GameObject[] enemySheets;

    public GameObject DMUI;

    public GameObject cam;

    private bool isGoblinActive = false;
    //private bool activator = true;
    // using this bool, I should be able to control the timing of the buttons, but I set up a test in the inspector to see if I need this or not (the test is the button events)

    private void Start()
    {
        //Splits the tabs into two groups so that seperate sides can be up at once
        tabsLeft = new GameObject[] { spawnEnemiesTab, viewEnemiesTab, musicOptionsTab };
        tabsRight = new GameObject[] { rollInitiativeTab, viewPlayerStatsTab, musicSettingsTab };

        //tabs = new GameObject[] { spawnEnemiesTab, viewEnemiesTab, musicOptionsTab, musicSettingsTab, rollInitiativeTab, viewPlayerStatsTab};
        //enemySheets = new GameObject[] { goblinSheet, VampireSheet };
        cam = GameObject.FindGameObjectWithTag("GMCharacter");
        DMUI.GetComponent<Canvas>().worldCamera = cam.GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        if(cam != null)
        {
            //makes the UI look at the GM
            this.transform.LookAt(new Vector3(cam.transform.position.x, this.transform.position.y, cam.transform.position.z));
        }
        
    }

    //Left side button click function
    public void OnButtonClickLeft(GameObject tab)
    {
        StartCoroutine(TabManagerLeft(tab));
    }
    
    //Closes the left tabs and opens the one selected
    IEnumerator TabManagerLeft(GameObject tab)
    {
        foreach (GameObject go in tabsLeft) { go.SetActive(false); }
        tab.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    //Right side button click functions
    public void OnButtonClickRight(GameObject tab)
    {
        StartCoroutine(TabManagerRight(tab));
    }

    //Closes the right tabs and opens the one selected
    IEnumerator TabManagerRight(GameObject tab)
    {
        foreach(GameObject go in tabsRight) { go.SetActive(false); }
        tab.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    //Sub page that opens when clicked on
    public void GoblinSheetButton(GameObject sheet)
    {
        if(!isGoblinActive)
        {
            sheet.SetActive(true);
            isGoblinActive = true;
        }
        else
        {
            sheet.SetActive(false);
            isGoblinActive = false;
        }
    }

    //IEnumerator EnemySheetManager(GameObject sheet)
    //{
    //    activator = false;
    //    foreach (GameObject go in enemySheets) { go.SetActive(false); }

    //    sheet.SetActive(true);
    //    yield return new WaitForSeconds(0.5f);
    //    activator = true;
    //}
}
