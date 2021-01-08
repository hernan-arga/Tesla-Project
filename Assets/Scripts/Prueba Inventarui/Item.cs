using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{

    public enum InteractionType { NONE, PickUp, Examine }
    public InteractionType interactionType;

    [Header("Examine")]
    public string descriptionText;


    //Interaction Type


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;

    }

    public void Interact()
    {
        switch (interactionType)
        {
            case InteractionType.PickUp:

                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);

                gameObject.SetActive(false);

                break;
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);

                Debug.Log("Examine");
                break;
            case InteractionType.NONE:
                Debug.Log("None");
                break;
        }
    }



}
