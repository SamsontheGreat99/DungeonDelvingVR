using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

//This script handles the board and playable environment spawning and destroying

public class ChangeEnvironmnets : MonoBehaviour
{
    private GameObject E1;
    public GameObject A1;
    public GameObject CastleEnvironment;
    public GameObject gameBoard;
    public GameObject playableArea;
    private Realtime realtime;
    private GameObject[] enemies;
    private GameObject[] networkEnemies;

    private Realtime.InstantiateOptions options;

    public GameObject e1;

    private void Start()
    {
        //Finding game board, playable area, realtime instance and setting realtime options
        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
        gameBoard = GameObject.FindGameObjectWithTag("BoardEnvironment1");
        playableArea = GameObject.FindGameObjectWithTag("PlayableEnvironment");
        options = new Realtime.InstantiateOptions
        {
            ownedByClient = false,
            preventOwnershipTakeover = true,
            useInstance = realtime,
            destroyWhenLastClientLeaves = true            
        };
        //e1 = Resources.Load("Environments/CastleEnvironment") as GameObject;
    }

    public void ShowE1()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        networkEnemies = GameObject.FindGameObjectsWithTag("Goblin");
        if(enemies != null)
        {
             foreach(GameObject enemy in enemies) { Destroy(enemy); }
            foreach (GameObject enemy in networkEnemies) { Realtime.Destroy(enemy); }

        }
        //This checks if the active environment is null before spawning the environments. If it is not null, it destroys the active one before spawning the new one
        //It is the same for all the following functions
        if (E1 == null)
        {
            E1 = Realtime.Instantiate("Environments/CastleEnvironment", options);
            A1 = Realtime.Instantiate("PlayableAreas/CastleEnvironment", options);
        }
        else
        {
            Realtime.Destroy(E1);
            Realtime.Destroy(A1);
            E1 = Realtime.Instantiate("Environments/CastleEnvironment", options);
            A1 = Realtime.Instantiate("PlayableAreas/CastleEnvironment", options);
        }
    }
    public void ShowE2()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        networkEnemies = GameObject.FindGameObjectsWithTag("Goblin");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies) { Destroy(enemy); }
            foreach (GameObject enemy in networkEnemies) { Realtime.Destroy(enemy); }

        }
        if (E1 == null)
        {
            E1 = Realtime.Instantiate("Environments/ForestStart", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestStart", options);
        }
        else
        {
            Realtime.Destroy(E1);
            Realtime.Destroy(A1);
            E1 = Realtime.Instantiate("Environments/ForestStart", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestStart", options);
        }
    }
    public void ShowE3()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        networkEnemies = GameObject.FindGameObjectsWithTag("Goblin");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies) { Destroy(enemy); }
            foreach (GameObject enemy in networkEnemies) { Realtime.Destroy(enemy); }

        }
        if (E1 == null)
        {
            E1 = Realtime.Instantiate("Environments/ForestRuins", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestRuins", options);
        }
        else
        {
            Realtime.Destroy(E1);
            Realtime.Destroy(A1);
            E1 = Realtime.Instantiate("Environments/ForestRuins", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestRuins", options);
        }
    }
    public void ShowE4()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        networkEnemies = GameObject.FindGameObjectsWithTag("Goblin");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies) { Destroy(enemy); }
            foreach (GameObject enemy in networkEnemies) { Realtime.Destroy(enemy); }

        }
        if (E1 == null)
        {
            E1 = Realtime.Instantiate("Environments/ForestHouse", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestHouse", options);
        }
        else
        {
            Realtime.Destroy(E1);
            Realtime.Destroy(A1);
            E1 = Realtime.Instantiate("Environments/ForestHouse", options);
            A1 = Realtime.Instantiate("PlayableAreas/ForestHouse", options);
        }
    }
    public void ClearBoard()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        networkEnemies = GameObject.FindGameObjectsWithTag("Goblin");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies) { Destroy(enemy); }
            foreach (GameObject enemy in networkEnemies) { Realtime.Destroy(enemy); }

        }
        if (E1 != null)
        {
            Realtime.Destroy(E1);
            Realtime.Destroy(A1);
        }
    }
}
