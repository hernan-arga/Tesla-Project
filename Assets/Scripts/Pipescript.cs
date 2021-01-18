using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pipescript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    public float[] correctRotation;
    public float[] rotationsWhereTheWaterPassFromRightOrUp;
    bool isPlaced = false;
    Animator animator;

    PipeManager pipeManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        pipeManager = GameObject.Find("PipeManager").GetComponent<PipeManager>();
    }
    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (correctRotation.Any(r => r.Equals(transform.eulerAngles.z)))
        {
            isPlaced = !isPlaced;
            pipeManager.CorrectMove();
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));        

        if (!isPlaced)
        {            
            if (correctRotation.Any(r => Approximately(transform.eulerAngles.z, r) ))
            {
                isPlaced = !isPlaced;
                pipeManager.CorrectMove();
            }           
        }

        else
        {
            isPlaced = !isPlaced;
            pipeManager.WrongMove();
        }
    }

    bool TheWaterPassFromRightOrUp() {
        return rotationsWhereTheWaterPassFromRightOrUp.Any(r => Approximately(transform.eulerAngles.z, r));        
    }

    public void PassWater()
    {
        if (TheWaterPassFromRightOrUp())
        {
            animator.SetTrigger("Fluid1");
        }
        
        else
        {
            animator.SetTrigger("Fluid2");
        }        
    }

    public bool IsFilled()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Pipe_Fill");
    }

    /*
     * Comparision between float with == or equals() is not precise, 
     * and Mathf.Approximately is not suitable for comparing an angle with a given value
     */
    bool Approximately(float aNumber, float anotherNumber)
    {
        return Mathf.Abs(aNumber- anotherNumber) < 1;
    }

    void Update()
    {
        
    }
}
