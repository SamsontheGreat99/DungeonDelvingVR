using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMUI : MonoBehaviour
{
    /* DO NOT USE THIS SCRIPT*/


    public GameObject xrRig;
    public GameObject Sword;
    public GameObject CharSheet;
    public GameObject DMUI_Canvas;
    private bool swordActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScaleUp()
    {
        xrRig.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void GiveSword()
    {
        if(swordActive == true)
        {
            Sword.SetActive(false);
            swordActive = false;
        }
        else
        {
            Sword.SetActive(true);
            swordActive = true;
        }
    }
    //not really for dm i dont think but testing
    public void OpenCharacterSheet()
    {
        CharSheet.SetActive(true);
        DMUI_Canvas.SetActive(false);
    }
    public void CloseCharacterSheet()
    {
        CharSheet.SetActive(false);
        DMUI_Canvas.SetActive(true);
    }
}
