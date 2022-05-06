using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This displays the crest image on the player sheet
public class DisplayCrest : MonoBehaviour
{
    public Sprite fighterCrest;
    public Sprite barbarianCrest;
    public Sprite paladinCrest;
    public Sprite rangerCrest;
    public Image crest;
    public CharacterStatsDisplay character;

    void Start()
    {
        if(character.className.text == "Fighter")
        {
            crest.sprite = fighterCrest;
        }
        else if (character.className.text == "Barabarian")
        {
            crest.sprite = barbarianCrest;
        }
        else if (character.className.text == "Paladin")
        {
            crest.sprite = paladinCrest;
        }
        else if (character.className.text == "Ranger")
        {
            crest.sprite = rangerCrest;
        }
    }
}
