using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityGenerator : MonoBehaviour
{
    // These modifier values are use for skills and health
    public static int strengthModifier;
    public static int dexterityModifier;
    public static int constitutionModifier;
    public static int intelligenceModifier;
    public static int wisdomModifier;
    public static int charismaModifier;

    // These values are used for the ability values
    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    // These are used for the AbilityScoreDiceRoll() function
    private List<int> numbers;
    private int addedValue;

    // This is so that I can call the AssignModifiers() function from PlayerSkillsGenerator
    private PlayerSkillsGenerator playerSkills;
    private PlayerProficiencies playerProficiencies;

    public void SetCharacterStats()
    {
        GenerateAbilityValues();
        AbilityModifierAssigner();
        PrintAbilities();
        PrintAbilityModifiers();
        playerSkills = GetComponent<PlayerSkillsGenerator>();
        playerSkills.AssignModifiers();
    }
    // Debugs ability values so you can see what they are
    private void PrintAbilities()
    {
        Debug.Log("Strength: " + strength);
        Debug.Log("Dexterity: " + dexterity);
        Debug.Log("Constitution: " + constitution);
        Debug.Log("Intelligence: " + intelligence);
        Debug.Log("Wisdom: " + wisdom);
        Debug.Log("Charisma: " + charisma);
    }
    // Assigns an ability score to each ability
    private void GenerateAbilityValues()
    {
        strength = AbilityScoreDiceRoll();
        dexterity = AbilityScoreDiceRoll();
        constitution = AbilityScoreDiceRoll();
        intelligence = AbilityScoreDiceRoll();
        wisdom = AbilityScoreDiceRoll();
        charisma = AbilityScoreDiceRoll();
    }
    // Rolls 4 D6 dice and adds the 3 highest values to find ability score
    private int AbilityScoreDiceRoll()
    {
        int value1 = Random.Range(1, 7);
        int value2 = Random.Range(1, 7);
        int value3 = Random.Range(1, 7);
        int value4 = Random.Range(1, 7);
        numbers = new List<int> { };
        numbers.Add(value1);
        numbers.Add(value2);
        numbers.Add(value3);
        numbers.Add(value4);
        numbers.Sort();
        numbers.Remove(numbers[0]);

        int total = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            total += numbers[i];
        }
        addedValue = total;

        return addedValue;
    }
    // Takes ability int as input and outputs the modifier for the ability
    private int ModifierCalculator(int input)
    {
        //I bet there is a better way to write this, but this works
        if (input == 1)
        {
            return -5;
        }
        else if (input == 2 | input == 3)
        {
            return -4;
        }
        else if (input == 4 | input == 5)
        {
            return -3;
        }
        else if (input == 6 | input == 7)
        {
            return -2;
        }
        else if (input == 8 | input == 9)
        {
            return -1;
        }
        else if (input == 10 | input == 11)
        {
            return 0;
        }
        else if (input == 12 | input == 13)
        {
            return 1;
        }
        else if (input == 14 | input == 15)
        {
            return 2;
        }
        else if (input == 16 | input == 17)
        {
            return 3;
        }
        else if (input == 18 | input == 19)
        {
            return 4;
        }
        else if (input == 20)
        {
            return 5;
        }
        return 0;
    }
    // Assigns modifier for each ability
    private void AbilityModifierAssigner()
    {
        strengthModifier = ModifierCalculator(strength);
        dexterityModifier = ModifierCalculator(dexterity);
        constitutionModifier = ModifierCalculator(constitution);
        intelligenceModifier = ModifierCalculator(intelligence);
        wisdomModifier = ModifierCalculator(wisdom);
        charismaModifier = ModifierCalculator(charisma);
    }
    // Debugs ability modifiers
    private void PrintAbilityModifiers()
    {
        Debug.Log("Strength Modifier: " + strengthModifier);
        Debug.Log("Dexterity Modifier: " + dexterityModifier);
        Debug.Log("Constitution Modifier: " + constitutionModifier);
        Debug.Log("Intelligence Modifier: " + intelligenceModifier);
        Debug.Log("Wisdom Modifier: " + wisdomModifier);
        Debug.Log("Charisma Modifier: " + charismaModifier);
    }
}
