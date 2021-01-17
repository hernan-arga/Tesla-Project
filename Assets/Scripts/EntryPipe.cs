using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPipe : MonoBehaviour
{
    PipeManager pipeManager;
    private void Awake()
    {
        pipeManager = GameObject.Find("PipeManager").GetComponent<PipeManager>();
    }

    private void OnMouseDown()
    {
        if (pipeManager.IsCorrectlyPlaced())
        {
            Debug.Log("igua unpodfoc ebri oesto");
        }

        else
        {
            pipeManager.TriggerPipeError();
        }
    }
}
