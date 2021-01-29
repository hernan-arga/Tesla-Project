using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{

    public enum InteractionType { NONE, PickUp, Examine, Action, Dialogue }
    public InteractionType interactionType;

    [Header("Examine")]
    public string descriptionText;

    [Header("Custom Event")]
    public UnityEvent customEvent; // Podemos llegar a usarlo depende

    [Header("Dialogue")]
    public GameObject dialogueObject;
    public bool isOneTimeDialogue;
    


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

                FindObjectOfType<InteractionSystem>().PickUpItem(this);

                gameObject.SetActive(false);

                break;
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);

                Debug.Log("Examine");
                break;
            case InteractionType.Action:
                ActionOnInteraction();
                Debug.Log("Action");
                break;
            case InteractionType.Dialogue:
                ActionOnDialogue();
                Debug.Log(isOneTimeDialogue ? "One Time Dialogue" : "Dialogue");
                break;
            case InteractionType.NONE:
                Debug.Log("None");
                break;
        }

        customEvent.Invoke();

    }

    public virtual void ActionOnInteraction()
    {
        Debug.Log("Bruh");
    }

    public virtual void ActionOnDialogue()
    {
        GameObject dialogo = isOneTimeDialogue ? dialogueObject : 
                GameObject.Instantiate(dialogueObject) as GameObject;

        if (dialogo != null) {
            dialogo.SetActive(true);
        }
    }

}
