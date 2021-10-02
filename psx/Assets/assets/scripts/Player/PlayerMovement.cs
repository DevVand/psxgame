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

    public bool moving = false;
    public Vector3 moveTo = Vector3.zero;
    public float moveToSmooth = 5;

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

        if (!moving)
        {
            Yvelocity -= gravity * Time.deltaTime;

            ground = Physics.CheckSphere(groundcheck.position, .1f, groundmask);
            if (ground && Yvelocity < 0)
            {
                Yvelocity = -2;
            }
                
            if (ground && Input.GetButtonDown("Jump"))
            {
                Yvelocity = Mathf.Sqrt(jump_height * 2f * gravity);
            }
            move = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

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
        }
        //controller.Move((transform.up * Yvelocity * Time.deltaTime));
    }
    private void FixedUpdate()
    {
        if (!moving)
        {
            if (move.magnitude > .01)
            {
                if (Input.GetButton("Run"))
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
        else {
            transform.position = Vector3.Slerp(transform.position, moveTo, Time.deltaTime * moveToSmooth);
        }
    }

    public void moveAt(Vector3 to)
    {
        anim.SetBool("walking", false);
        anim.SetBool("running", false);
        moving = true;
        moveTo = to;
    }
    public void noMoveAt()
    {
        moving = false;
    }
    public void DisablePlayerMovement ()
    {
        enabled = false;
        anim.enabled = false;
    }

    public void EnablePlayerMovement ()
    {
        enabled = true;
        anim.enabled = true;
    }
    public void motionSicknessMode(bool to) {
        anim.SetBool("motionSicknessMode", to);
    }
}