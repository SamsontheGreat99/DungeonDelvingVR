using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Nametag : MonoBehaviour
{
    //make a name list
    private List<string> nameList = new List<string>();
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        //get the current folder
        string currentFolder = Directory.GetCurrentDirectory();
        //get the file path
        string filePath = currentFolder + "/Assets/Scripts/UIScripts/Namelist.txt";
        Debug.Log(filePath);
        //read the file
        StreamReader reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            //add the names to the list
            nameList.Add(reader.ReadLine());
        }
        //close the file
        reader.Close();
        //randomly assign a name to the nametag
        int random = Random.Range(0, nameList.Count);
        //get the text component
        //nameText = GetComponent<TextMeshProUGUI>();
        //set the text to the name
        nameText.text = nameList[random];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
