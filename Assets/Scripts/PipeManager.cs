using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    public int totalPipes = 0;
    public int correctedPipes = 0;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes];
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }
    public void TriggerPipeError()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    public void CorrectMove()
    {
        correctedPipes++;
        
    }

    public bool IsCorrectlyPlaced()
    {
        return correctedPipes == totalPipes;
    }

    public void WrongMove()
    {
        correctedPipes--;
    }
}
