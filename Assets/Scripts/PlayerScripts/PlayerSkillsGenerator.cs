using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsGenerator : MonoBehaviour
{
    //Strength Skills
    public int athletics;

    //Dexterity Skills
    public int acrobatics;
    public int sleightOfHand;
    public int stealth;

    //Intelligence Skills
    public int arcana;
    public int history;
    public int investigation;
    public int nature;
    public int religion;

    //Wisdom Skills
    public int animalHandling;
    public int insight;
    public int medicine;
    public int perception;
    public int survival;

    //Charisma Skills
    public int deception;
    public int intimidation;
    public int performance;
    public int persuasion;

    // Assigns skill modifiers equal to the value of their respective ability modifiers
    public void AssignModifiers()
    {
        //Strength Skills
        athletics = PlayerAbilityGenerator.strengthModifier;

        //Dexterity Skills
        acrobatics = PlayerAbilityGenerator.dexterityModifier;
        sleightOfHand = PlayerAbilityGenerator.dexterityModifier;
        stealth = PlayerAbilityGenerator.dexterityModifier;

        //Intelligence Skills
        arcana = PlayerAbilityGenerator.intelligenceModifier;
        history = PlayerAbilityGenerator.intelligenceModifier;
        investigation = PlayerAbilityGenerator.intelligenceModifier;
        nature = PlayerAbilityGenerator.intelligenceModifier;
        religion = PlayerAbilityGenerator.intelligenceModifier;

        //Wisdom Skills
        animalHandling = PlayerAbilityGenerator.wisdomModifier;
        insight = PlayerAbilityGenerator.wisdomModifier;
        medicine = PlayerAbilityGenerator.wisdomModifier;
        perception = PlayerAbilityGenerator.wisdomModifier;
        survival = PlayerAbilityGenerator.wisdomModifier;

        //Charisma Skills
        deception = PlayerAbilityGenerator.charismaModifier;
        intimidation = PlayerAbilityGenerator.charismaModifier;
        performance = PlayerAbilityGenerator.charismaModifier;
        persuasion = PlayerAbilityGenerator.charismaModifier;
    }
}
