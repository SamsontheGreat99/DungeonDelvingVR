using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script assigns the proficiencies for the classes based on what skill they would most need in the game
//It does this by accessing the skillsgenerator script and adding 2 to two of the skills

public class PlayerProficiencies : MonoBehaviour
{
    private PlayerSkillsGenerator skills;

   public void AssignPlayerProficiencies()
    {
        skills = GetComponent<PlayerSkillsGenerator>();
        skills.investigation += 2;
        skills.perception += 2;
        Debug.Log("Investigation: " + skills.investigation);
        Debug.Log("perception: " + skills.perception);
    }
    public void AssignPaladinProficiencies()
    {
        skills = GetComponent<PlayerSkillsGenerator>();
        skills.athletics += 2;
        skills.intimidation += 2;
    }
    public void AssignFighterProficiencies()
    {
        skills = GetComponent<PlayerSkillsGenerator>();
        skills.athletics += 2;
        skills.acrobatics += 2;
        Debug.Log("Athletics: " + skills.athletics);
        Debug.Log("Acrobatics: " + skills.acrobatics);
    }
    public void AssignBarbarianProficiencies()
    {
        skills = GetComponent<PlayerSkillsGenerator>();
        skills.athletics += 2;
        skills.acrobatics += 2;
    }
    public void AssignRangerProficiencies()
    {
        skills = GetComponent<PlayerSkillsGenerator>();
        skills.acrobatics += 2;
        skills.stealth += 2;
    }
}
