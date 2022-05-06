using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//This script assigns skills based off of ability values

public class CharacterStatsDisplay : MonoBehaviour
{
    public PlayerSkillsGenerator playerSkillsGenerator;
    public Transform xrRig;
    public TextMeshProUGUI healthText;
    public Button healthUpButton;
    public Button healthDownButton;
    public int maxHealthInt;
    public int currentHealth;
    //public Button[] healthButtons;
    public TextMeshProUGUI className;

    //Need to come implement currentHealth when we implement fighting
    //public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI maxHealth;

    public TextMeshProUGUI strengthValue;
    public TextMeshProUGUI dexterityValue;
    public TextMeshProUGUI constitutionValue;
    public TextMeshProUGUI intelligenceValue;
    public TextMeshProUGUI wisdomValue;
    public TextMeshProUGUI charismaValue;

    public TextMeshProUGUI AcrobaticsValue;
    public TextMeshProUGUI AnimalHandlingValue;
    public TextMeshProUGUI ArcanaValue;
    public TextMeshProUGUI AthleticsValue;
    public TextMeshProUGUI DeceptionValue;
    public TextMeshProUGUI HistoryValue;
    public TextMeshProUGUI InsightValue;
    public TextMeshProUGUI IntimidationValue;
    public TextMeshProUGUI InvestigationValue;
    public TextMeshProUGUI MedicineValue;
    public TextMeshProUGUI NatureValue;
    public TextMeshProUGUI PerceptionValue;
    public TextMeshProUGUI PerformanceValue;
    public TextMeshProUGUI PersuasionValue;
    public TextMeshProUGUI ReligionValue;
    public TextMeshProUGUI SleightOfHandValue;
    public TextMeshProUGUI StealthValue;
    public TextMeshProUGUI SurvivalValue;

    // Start is called before the first frame update
    void Start()
    {
        xrRig = this.transform.parent.parent;
        playerSkillsGenerator = xrRig.GetComponentInChildren<PlayerSkillsGenerator>();
        className.text = PlayerAssignment.CLASS.ToString();

        // will need to update this with currentHealth when we implement fighting
        if (PlayerAssignment.CLASS == PlayerClass.Fighter)
        {
            maxHealth.text = "HP: " + FighterClass.health + "/" + FighterClass.health;
            maxHealthInt = FighterClass.health;
            currentHealth = maxHealthInt;
        }
        else if(PlayerAssignment.CLASS == PlayerClass.Barbarian)
        {
            maxHealth.text = "HP: " + BarbarianClass.health + "/" + BarbarianClass.health;
            maxHealthInt = BarbarianClass.health;
            currentHealth = maxHealthInt;
        }
        else if(PlayerAssignment.CLASS == PlayerClass.Paladin)
        {
            maxHealth.text = "HP: " + PaladinClass.health + "/" + PaladinClass.health;
            maxHealthInt = PaladinClass.health;
            currentHealth = maxHealthInt;
        }
        else if(PlayerAssignment.CLASS == PlayerClass.Ranger)
        {
            maxHealth.text = "HP: " + RangerClass.health + "/" + RangerClass.health;
            maxHealthInt = RangerClass.health;
            currentHealth = maxHealthInt;
        }

        //This displays the values of the skills and abilities and assigns a plus or minus sign to them
        strengthValue.text = PlusOrMinus(PlayerAbilityGenerator.strengthModifier);
        dexterityValue.text = PlusOrMinus(PlayerAbilityGenerator.dexterityModifier);
        constitutionValue.text = PlusOrMinus(PlayerAbilityGenerator.constitutionModifier);
        intelligenceValue.text = PlusOrMinus(PlayerAbilityGenerator.intelligenceModifier);
        wisdomValue.text = PlusOrMinus(PlayerAbilityGenerator.wisdomModifier);
        charismaValue.text = PlusOrMinus(PlayerAbilityGenerator.charismaModifier);


        AcrobaticsValue.text = PlusOrMinus(playerSkillsGenerator.acrobatics.ToString());
        AnimalHandlingValue.text = PlusOrMinus(playerSkillsGenerator.animalHandling.ToString());
        ArcanaValue.text = PlusOrMinus(playerSkillsGenerator.arcana.ToString());
        AthleticsValue.text = PlusOrMinus(playerSkillsGenerator.athletics.ToString());
        DeceptionValue.text = PlusOrMinus(playerSkillsGenerator.deception.ToString());
        HistoryValue.text = PlusOrMinus(playerSkillsGenerator.history.ToString());
        InsightValue.text = PlusOrMinus(playerSkillsGenerator.insight.ToString());
        IntimidationValue.text = PlusOrMinus(playerSkillsGenerator.intimidation.ToString());
        InvestigationValue.text = PlusOrMinus(playerSkillsGenerator.investigation.ToString());
        MedicineValue.text = PlusOrMinus(playerSkillsGenerator.medicine.ToString());
        NatureValue.text = PlusOrMinus(playerSkillsGenerator.nature.ToString());
        PerceptionValue.text = PlusOrMinus(playerSkillsGenerator.perception.ToString());
        PerformanceValue.text = PlusOrMinus(playerSkillsGenerator.performance.ToString());
        PersuasionValue.text = PlusOrMinus(playerSkillsGenerator.persuasion.ToString());
        ReligionValue.text = PlusOrMinus(playerSkillsGenerator.religion.ToString());
        SleightOfHandValue.text = PlusOrMinus(playerSkillsGenerator.sleightOfHand.ToString());
        StealthValue.text = PlusOrMinus(playerSkillsGenerator.stealth.ToString());
        SurvivalValue.text = PlusOrMinus(playerSkillsGenerator.survival.ToString());
    }

    // The next two functions assign a plus or minus, one needs a string overload and the other needs an int overload depending on what it passes through
    private string PlusOrMinus(string text)
    {
        if(int.Parse(text) > 0)
        {
            text = "+" + text;
            return text;
        }
        else
        {
            return text;
        }
    }
    private string PlusOrMinus(int text)
    {
        string returnText;
        if(text > 0)
        {
            returnText = "+" + text;
            return returnText;
        }
        else
        {
            returnText = text.ToString();
            return returnText;
        }
    }

    //Adds player health
    public void UpHealthButtonPressed()
    {
        //StartCoroutine(HealthAdjustment(1, true, healthUpButton));
        currentHealth += 1;
        if(currentHealth >= maxHealthInt)
        {
            currentHealth = maxHealthInt;
        }
        healthText.text = "HP: " + currentHealth + "/" + maxHealthInt;
    }

    //Subtracts player health
    public void DownHealthButtonPressed()
    {
        //StartCoroutine(HealthAdjustment(-1, true, healthDownButton));
        currentHealth -= 1;
        if (currentHealth >= maxHealthInt)
        {
            currentHealth = maxHealthInt;
        }
        healthText.text = "HP: " + currentHealth + "/" + maxHealthInt;
    }

    //This is not used because it broke everything, but it was supposed to split the string passed through it and then recombine it at the end, it was going to be beautiful
    IEnumerator HealthAdjustment(int amount, bool isPressed, Button buttonPressed)
    {
        buttonPressed.interactable = false;
        string healthDisplay = healthText.text;
        if (isPressed)
        {
            string[] split1 = healthDisplay.Split(' ');
            string[] split2 = split1[1].Split('/');
            int currentHealth = int.Parse(split2[0]);
            int maxHealth = int.Parse(split2[1]);

            currentHealth -= amount;

            healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        }
        yield return new WaitForSeconds(0.2f);
        buttonPressed.interactable = true;
        isPressed = false;
    }
}
