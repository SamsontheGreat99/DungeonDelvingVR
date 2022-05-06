using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int barbarianHealth;
    public static int fighterHealth;
    public static int paladinHealth;
    public static int rangerHealth;

    // Set health for Barbarian based on level
    public int SetBarbarianHealth(int level)
    {
        barbarianHealth = 12 * level + PlayerAbilityGenerator.constitutionModifier;
        return barbarianHealth;
    }
    // Set health for Fighter based on level
    public int SetFighterHealth(int level)
    {
        fighterHealth = 10 * level + PlayerAbilityGenerator.constitutionModifier;
        return fighterHealth;
    }
    // Set health for Paladin based on level
    public int SetPaladinHealth(int level)
    {
        paladinHealth = 10 * level + PlayerAbilityGenerator.constitutionModifier;
        return paladinHealth;
    }
    // Set health for Ranger based on level
    public int SetRangerHealth(int level)
    {
        rangerHealth = 10 * level + PlayerAbilityGenerator.constitutionModifier;
        return rangerHealth;
    }
}
