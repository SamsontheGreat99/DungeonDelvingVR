using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THis class assigns the player health, abilities, and proficiencies


public class PaladinClass : MonoBehaviour
{
    public int level = 1;
    public static int health;
    private PlayerHealth playerHealth;
    private PlayerAbilityGenerator playerAbilityGenerator;
    private PlayerProficiencies playerProficiencies;
    // Start is called before the first frame update
    void Start()
    {
        //Calls the scipts, then calls the script's method


        //calling the PlayerHealth script to get health for fighter class
        playerHealth = GetComponent<PlayerHealth>();
        playerAbilityGenerator = GetComponent<PlayerAbilityGenerator>();
        playerProficiencies = GetComponent<PlayerProficiencies>();

        playerAbilityGenerator.SetCharacterStats();
        playerProficiencies.AssignPaladinProficiencies();
        health = playerHealth.SetPaladinHealth(level);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
