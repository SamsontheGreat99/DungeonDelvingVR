using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceColors : MonoBehaviour
{
    public GameObject fd;
    public GameObject bd;
    public GameObject rd;
    public GameObject pd;
    public Material fmat;
    public Material bmat;
    public Material rmat;
    public Material pmat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fd = GameObject.Find("Fighterdice");
        bd = GameObject.Find("Barbariandice");
        rd = GameObject.Find("Rangerdice");
        pd = GameObject.Find("Paladindice");
        if (fd != null)
        {
            Renderer rend = fd.GetComponent<Renderer>();
            rend.material = fmat;
            //d4.name = "d4 colored";
        }
        if (bd != null)
        {
            Renderer rend = bd.GetComponent<Renderer>();
            rend.material = bmat;
            //d4.name = "d4 colored";
        }
        if (rd != null)
        {
            Renderer rend = rd.GetComponent<Renderer>();
            rend.material = rmat;
            //d4.name = "d4 colored";
        }
        if (pd != null)
        {
            Renderer rend = pd.GetComponent<Renderer>();
            rend.material = pmat;
            //d4.name = "d4 colored";
        }


        /*
        Idea for the dice. What if the script was on the dice itself and controlled the color that way, so you could check the name of itself:

        if(this.name == "Fighterdice")
        {
            Renderer rend = this.GetComponent<Renderer>();
            rend.material = rmat;
        }
         */
    }
}

