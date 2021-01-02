using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;
    private float move = 0f;
    public float speed = 8f;
    public bool active = true;
    private bool estaCaminando = false;
    public Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (active)
        {
            move = Input.GetAxisRaw("Horizontal");

            if (Input.GetKey(KeyCode.D))
            {
                estaCaminando = true;
                transform.localScale = new Vector3(move, 1f, 1f);

            }
            else if(Input.GetKey(KeyCode.A))
            {
                estaCaminando = true;
                transform.localScale = new Vector3(move, 1f, 1f);
            }
            
            rigidBody.velocity = new Vector3(speed * move, rigidBody.velocity.y, rigidBody.velocity.z);

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rigidBody.velocity = new Vector3(0f, 0f, 0f);
            }

        }
        

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || !active)
        {
            estaCaminando = false;
            rigidBody.velocity = (new Vector3(0, 0, 0));
        }

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            ControlarInventario();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            estaCaminando = false;
        }

        SetearAnimaciones();
    }

    private void SetearAnimaciones()
    {
        animator.SetBool("estaCaminando", estaCaminando);
    }
    private void ControlarInventario()
    {        

        if (inventory.GetActive())
        {
            inventory.Desactivate();
            active = true;
        }

        else
        {
            inventory.Activate();            
            active = false;
        }
    }
}
