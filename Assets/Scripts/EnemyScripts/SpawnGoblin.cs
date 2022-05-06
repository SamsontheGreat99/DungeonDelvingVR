using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

// This script handles the spawing of the goblin enemy for the game master and for the server
public class SpawnGoblin : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy;
    public GameObject[] parents;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    public List<GameObject> activeGoblins;

    private Realtime.InstantiateOptions options;
    private Realtime realtime;

    private void Start()
    {
        //In start, the script find the spawn points and then loads the interactable goblin figurine, then starts a list of active goblins, then creates the options for spawning on the server
        parents = GameObject.FindGameObjectsWithTag("SpawnPoint");
        enemyPrefab = Resources.Load("Characters/GoblinInteractable") as GameObject;
        activeGoblins = new List<GameObject>();

        realtime = GameObject.FindGameObjectWithTag("Realtime").GetComponent<Realtime>();
        options = new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            useInstance = realtime,
            destroyWhenLastClientLeaves = true
        };
    }

    public void SpawnGoblinEnemy()
    {
        //loops through the spawn points, clears the list, instantiates the enemies, clears out the transforms, and then spawns a networked goblin
        foreach(GameObject go in parents)
        {
            activeGoblins.Clear();
            Debug.Log("Spawn");
            enemy = Instantiate(enemyPrefab, go.transform);
            activeGoblins.Add(enemy);
            enemyPrefab.transform.position = Vector3.zero;
            enemyPrefab.transform.localPosition = Vector3.zero;
            SpawnNetworkedGoblin(enemy);
            skinnedMeshRenderers = enemy.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach(SkinnedMeshRenderer skin in skinnedMeshRenderers)
            {
                skin.enabled = false;
            }
        }
        Debug.Log(activeGoblins.Count);
        foreach(GameObject go in activeGoblins)
        {
            Debug.Log("Reposition");
            go.transform.localPosition = Vector3.zero;
        }
    }

    //function to spawn the networked goblin and sends the local goblin as the target
    public void SpawnNetworkedGoblin(GameObject target)
    {
        GameObject goblin = Realtime.Instantiate("Characters/NetworkedGoblin", options);
        goblin.GetComponent<NetworkedGoblin>().target = target;
    }
}
