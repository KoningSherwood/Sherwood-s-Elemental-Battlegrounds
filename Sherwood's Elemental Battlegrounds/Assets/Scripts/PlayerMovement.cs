using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove, isRunning;
    public float speed, walkSpeed, runSpeed, speedBoost;
    public Animator playerAnimations;

    private void Start()
    {
        speed = walkSpeed;
    }

    private void Update()
    {
        if (canMove)
        {
            Movement();
        }
    }

    public void Movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isRunning = !isRunning;
            Debug.Log("Toggled Run");
        }

        if (ver != 0 || hor != 0)
        {
            playerAnimations.SetBool("IsIdle", false);
            playerAnimations.SetFloat("Hor", hor);
            playerAnimations.SetFloat("Ver", ver);

            if (isRunning && ver > 0)
            {
                speed = runSpeed + speedBoost;
                playerAnimations.SetBool("IsRunning", true);
            }
            else
            {
                speed = walkSpeed + speedBoost;
                playerAnimations.SetBool("IsRunning", false);
            }

            transform.Translate(Vector3.forward * ver * speed * Time.deltaTime, Space.Self);
            transform.Translate(Vector3.right * hor * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            playerAnimations.SetBool("IsIdle", true);
            playerAnimations.SetBool("IsRunning", false);
            playerAnimations.SetFloat("Hor", 0);
            playerAnimations.SetFloat("Ver", 0);
        }
    }
}