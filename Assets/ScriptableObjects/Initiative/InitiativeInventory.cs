using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Initiatives Object", menuName ="Initiatives")]
public class InitiativeInventory : ScriptableObject
{
    public List<PlayerValues> Container = new List<PlayerValues>();

   

    public void AddPlayer(string _name, int _value)
    {
        bool hasPlayer = false;

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].NAME == _name)
            {
                Container[i].VALUE = _value;
                hasPlayer = true;
                break;
            }
        }
        if (!hasPlayer)
        {
            Container.Add(new PlayerValues(_name, _value));
        }
    }
 
}
[System.Serializable]
public class PlayerValues
{
    public string NAME;
    public int VALUE;
    public GameObject prefab;

    public PlayerValues(string _name, int _value)
    {
        NAME = _name;
        VALUE = _value;
    }
}
