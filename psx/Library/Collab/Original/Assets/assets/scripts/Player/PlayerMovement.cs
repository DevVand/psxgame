using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public float runmultplier = 2;

    public float gravity = 14f;
    public float jump_height = 1;

    private float Yvelocity = 0;

    private Vector2 move = Vector2.zero;

    public Animator anim;
    CharacterController controller;
    public Transform groundcheck;
    public LayerMask groundmask;
    bool ground = false;
    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

void Update()
    {

        Yvelocity -= gravity * Time.deltaTime;

        ground = Physics.CheckSphere(groundcheck.position, .1f, groundmask);
        if (ground && Yvelocity < 0)
        {
            Yvelocity = -.5f;
        }

        if (ground && Input.GetButtonDown("Jump"))
        {
            Yvelocity = Mathf.Sqrt(jump_height * 2f * gravity);
        }
        move = new Vector2(Input.GetAxis("Horizontal") * speed , Input.GetAxis("Vertical") * speed);

        if (move.magnitude > .01)
        {
            anim.SetBool("walking", true);
            if (Input.GetKey(KeyCode.LeftShift))
                anim.SetBool("running", true);
            else
                anim.SetBool("running", false);
        }
        else
        {
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
        }
        controller.Move((transform.up * Yvelocity * Time.deltaTime));
    }
    private void FixedUpdate()
    {
        if (move.magnitude > .01)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move((((transform.right * move.x) + (transform.forward * move.y)) * runmultplier) * Time.deltaTime);
            }
            else
            {
                controller.Move(((transform.right * move.x) + (transform.forward * move.y)) * Time.deltaTime);
            }
        }
        controller.Move((transform.up * Yvelocity * Time.deltaTime));
    }
}