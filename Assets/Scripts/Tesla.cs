using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;
    private float move = 0f;
    public float speed = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("estaCaminando", true);
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("estaCaminando", true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        move = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector3(speed * move, rigidBody.velocity.y, rigidBody.velocity.z);


        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) 
        {
            animator.SetBool("estaCaminando", false);
            rigidBody.velocity = (new Vector3(0, 0, 0));
        }

        
    }
}
