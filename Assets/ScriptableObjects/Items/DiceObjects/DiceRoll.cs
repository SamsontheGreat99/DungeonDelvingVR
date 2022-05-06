using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    //This script is responsible for the dice rolling mechanics

    public int diceValue;
    public GameObject[] diceNumber;

    //This function inputs the value of the dice roll and updates the text on the dice to that value
    public void RollDice(int value)
    {
        for (int i = 0; i < diceNumber.Length; i++)
        {
            TextMeshPro die = diceNumber[i].GetComponent<TextMeshPro>(); 
            die.text = value.ToString();
            if(value == 6 | value == 9)
            {
                die.fontStyle = FontStyles.Underline;
            }
            else
            {
                die.fontStyle = FontStyles.Normal;
            }
        }
    }

    //Functions below are responsible for simulating the dice rolls
    public void RollDice4()
    {
        diceValue = Random.Range(1, 5);
        RollDice(diceValue);
    }
    public void RollDiceD6()
    {
        diceValue = Random.Range(1, 7);
        RollDice(diceValue);
    }
    public void RollDiceD8()
    {
        diceValue = Random.Range(1, 9);
        RollDice(diceValue);
    }
    public void RollDiceD10()
    {
        diceValue = Random.Range(1, 11);
        RollDice(diceValue);
    }
    public void RollDiceD12()
    {
        diceValue = Random.Range(1, 13);
        RollDice(diceValue);
    }
    public void RollDiceD20()
    {
        diceValue = Random.Range(1, 21);
        RollDice(diceValue);
    }
    public void RollDiceD100()
    {
        diceValue = Random.Range(1, 101);
        RollDice(diceValue);
    }
}
