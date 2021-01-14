using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class paloma: Item
{

    public enum InteractionType { NONE, PickUp, Examine }
    public InteractionType interactionType;

    [Header("Examine")]
    public string descriptionText;

    [Header("Custom Event")]
    public UnityEvent customEvent; // Podemos llegar a usarlo depende

    /* Declaracion de variables TODO: USARLA CUANDO VUELE
    int direccion;
    float velVuelo = 13f;
    */
    public AudioSource palomaSource;
    public Animator animator;
    bool fueAcosada = false;

    // Start is called before the first frame update
    void Start()
    {
        palomaSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
        fueAcosada = false;

    }

    public void Interact()
    {
        switch (interactionType)
        {
            case InteractionType.Examine:
                updatePanico();
                Debug.Log("Examine");
                break;
            default:
                Debug.Log("None");
                break;
        }

        customEvent.Invoke();

    }

    void updatePanico()
    {
        fueAcosada = !fueAcosada;
        animator.SetBool("fueAcosada", fueAcosada);

        if (fueAcosada)
        {
            palomaSource.Play();
        }
        else
        {
            palomaSource.Stop();
        }
    }
}
