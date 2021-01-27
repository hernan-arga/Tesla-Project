using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farola : Item
{
    public GameObject dialogoDeFarola;
    
    // Start is called before the first frame update
    public override void ActionOnInteraction()
    {
        GameObject dialogoFarola = GameObject.Instantiate(dialogoDeFarola) as GameObject;
        dialogoFarola.SetActive(true);
    }
}
