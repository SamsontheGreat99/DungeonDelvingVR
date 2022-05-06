using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;
using TMPro;

public class GetDice : MonoBehaviour
{
    //This script creates the dice that the player will have available to them

    //This is the array for the dice
    public DiceObject[] DICE = new DiceObject[8];

    //realtime instantiation options
    private Realtime realtime;
    private Realtime.InstantiateOptions options;

    public string Classes;

    bool isDiceSpawned = false;
    public GameObject ACTIVEDICE;
    public GameObject NETWORKEDDICE;

    private void Start()
    {
        //In start we find the realtime component of the game so that we create the object in the right room and set the options for it
        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
        options = new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            useInstance = realtime,
            destroyWhenLastClientLeaves = true
        };

        //Then we assign the dice
        AssignD4Dice();
        AssignD6Dice();
        AssignD8Dice();
        AssignD10Dice();
        AssignD12Dice();
        AssignD20Dice();
    }

    //The Assign#Dice functions below define the characteristics of the dice based on the scriptable object called DiceObject
    //probably the most important is the realtimePrefab which gives the game a path to create the dice on the server
    private void AssignD4Dice()
    {
        DICE[0] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[0].name = "D4";
        DICE[0].type = ItemType.Dice;
        DICE[0].sides = 4;
        DICE[0].displayName = "D4";
        DICE[0].prefab = Resources.Load("InteractablePrefabs/d4 Variant") as GameObject;
        DICE[0].realtimePrefab = "NetworkedD4";
    }
    private void AssignD6Dice()
    {
        DICE[1] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[1].name = "D6";
        DICE[1].type = ItemType.Dice;
        DICE[1].sides = 6;
        DICE[1].displayName = "D6";
        DICE[1].prefab = Resources.Load("InteractablePrefabs/d6 Variant") as GameObject;
        DICE[1].realtimePrefab = "NetworkedD6";
    }
    private void AssignD8Dice()
    {
        DICE[2] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[2].name = "D8";
        DICE[2].type = ItemType.Dice;
        DICE[2].sides = 8;
        DICE[2].displayName = "D8";
        DICE[2].prefab = Resources.Load("InteractablePrefabs/d8 Variant") as GameObject;
        DICE[2].realtimePrefab = "NetworkedD8";
    }
    private void AssignD10Dice()
    {
        DICE[3] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[3].name = "D10";
        DICE[3].type = ItemType.Dice;
        DICE[3].sides = 10;
        DICE[3].displayName = "D10";
        DICE[3].prefab = Resources.Load("InteractablePrefabs/d10 Variant") as GameObject;
        DICE[3].realtimePrefab = "NetworkedD10";
    }
    private void AssignD12Dice()
    {
        DICE[4] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[4].name = "D12";
        DICE[4].type = ItemType.Dice;
        DICE[4].sides = 12;
        DICE[4].displayName = "D12";
        DICE[4].prefab = Resources.Load("InteractablePrefabs/d12 Variant") as GameObject;
        DICE[4].realtimePrefab = "NetworkedD12";
    }
    private void AssignD20Dice()
    {
        DICE[5] = ScriptableObject.CreateInstance<DiceObject>();
        DICE[5].name = "D20";
        DICE[5].type = ItemType.Dice;
        DICE[5].sides = 20;
        DICE[5].displayName = "D20";
        DICE[5].prefab = Resources.Load("InteractablePrefabs/d20 wrong") as GameObject;
        DICE[5].realtimePrefab = "NetworkedD20";
    }

   

    //This function spawns the dice
    public void SpawnDice(int index)
    {
        if (!isDiceSpawned)
        {
            //this.GetComponent<Button>().interactable = false;
            StartCoroutine("Spawn", index);
        }
        else
        {
            //this.GetComponent<Button>().interactable = false;
            StartCoroutine("DeSpawn", index);
        }

    }

    public GameObject SpawnNetworkedDice(GameObject target, string prefab)
    {
        GameObject dice = Realtime.Instantiate(prefab, options);
        dice.GetComponent<NetworkedDice>().target = ACTIVEDICE;
        return dice;
    }

    //the Spawn IEnumerator first deletes the dice if there already is one, and then creates the new one
    IEnumerator Spawn(int index)
    {
        if(ACTIVEDICE != null)
        {
            Destroy(ACTIVEDICE);
            Realtime.Destroy(NETWORKEDDICE);
        }
        //ACTIVEDICE = Instantiate(DICE[index].prefab);
        ACTIVEDICE = Instantiate(DICE[index].prefab);
        ACTIVEDICE.transform.position = this.transform.position;
        NETWORKEDDICE = SpawnNetworkedDice(ACTIVEDICE, DICE[index].realtimePrefab);
        Classes = this.GetComponent<CharacterStatsDisplay>().className.text;
        if (Classes == "Fighter")
        {
            ACTIVEDICE.name = "Fighterdice";
            NETWORKEDDICE.name = "Fighterdice";
        }
        if (Classes == "Barbarian")
        {
            ACTIVEDICE.name = "Barbariandice";
            NETWORKEDDICE.name = "Barbariandice";
        }
        if (Classes == "Ranger")
        {
            ACTIVEDICE.name = "Rangerdice";
            NETWORKEDDICE.name = "Rangerdice";
        }
        if (Classes == "Paladin")
        {
            ACTIVEDICE.name = "Paladindice";
            NETWORKEDDICE.name = "Paladindice";
        }
        yield return new WaitForSeconds(1f);
        //this.GetComponent<Button>().interactable = true;
    }

    //This destroys the active dice instance and is called in the Spawn above
    IEnumerator DeSpawn(int index)
    {
        Destroy(ACTIVEDICE);
        Realtime.Destroy(NETWORKEDDICE);
        yield return new WaitForSeconds(1f);
        //this.GetComponent<Button>().interactable = true;
    }
}
