using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPipe : MonoBehaviour
{
    PipeManager pipeManager;
    Animator animator;
    GameObject gear;
    private void Awake()
    {
        gear = transform.Find("Gear").gameObject;
        animator = GetComponent<Animator>();
        pipeManager = GameObject.Find("PipeManager").GetComponent<PipeManager>();
    }

    private void OnMouseDown()
    {
        if (pipeManager.IsCorrectlyPlaced())
        {
            pipeManager.TriggerPipeSuccessful();
        }

        else
        {
            pipeManager.TriggerPipeError();
        }
    }

    public bool FinishTurn(){
        return gear.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Pipe_Idle");
    }

    public void TriggerPipe()
    {
        gear.GetComponent<Animator>().SetTrigger("Turn");
    }
}
