using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class paloma: Item
{

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

    public override void ActionOnInteraction()
    {
        Debug.Log("Cotorra moment");
        updatePanico();
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
