using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{

    public enum InteractionType { NONE, PickUp, Examine }
    public InteractionType type;

    //Interaction Type


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;

    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:

                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);

                gameObject.SetActive(false);
          
                break;
            case InteractionType.Examine:
                Debug.Log("Examine");
                break;
            case InteractionType.NONE:
                Debug.Log("None");
                break;
        }
    }


}
