using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To make camira to look like assisantcreed press    shift+ctrl+F 
// Remember Y axis and x axis + 
public class Playermove : MonoBehaviour
{

    private CharacterController charController;
    private CharacterAnimation PlayerAnimation;

    public float movementspeed = 3f;
    public float gravity = 9.8f;
    public float rotationspeed = 0.15f;
    public float rotatedegreespersec = 180f;


    // 1st fun. is called
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        PlayerAnimation = GetComponent<CharacterAnimation>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move ()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)  // if push W or up arrow  ,  file Tags instead of "Vertical" we write what inside the bracies
        {
            Vector3 moveDirection = transform.forward; // move to x axis
            moveDirection.y -= gravity * Time.deltaTime; // apply gravity manually , Time.deltaTime  is the diff. between each frame 
            charController.Move(moveDirection * movementspeed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0) // if push S or down arrow
        {
            Vector3 moveDirection = - transform.forward; // move to y axis using -  we don't have backward
            moveDirection.y -= gravity * Time.deltaTime; // apply gravity manually , Time.deltaTime  is the diff. between each frame 
            charController.Move(moveDirection * movementspeed * Time.deltaTime);
        }
        else   // if we don't have any input to move the character
        {
            charController.Move(Vector3.zero);
        }
    }

    void Rotate ()
    {
        Vector3 rotationDirection = Vector3.zero; // Vector3.zero == vector3 = 0,0,0 for x,y,z
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)  // if push A or left arrow  ,  file Tags instead of "Horizontal" we write what inside the bracies
        {
           rotationDirection = transform.TransformDirection(Vector3.left); // move to left
            
        }
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0) // if push D or Right arrow
        {
           rotationDirection = transform.TransformDirection(Vector3.right); // move to Right
          
        }
        // we don't use else if to not cancel each other 

        if (rotationDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.LookRotation(rotationDirection)
                                                            , rotatedegreespersec * Time.deltaTime);
        }

    }

    void AnimateWalk ()
    {
        if (charController.velocity.sqrMagnitude !=0f)
        {
            PlayerAnimation.Walk(true);
        }else
        {
            PlayerAnimation.Walk(false);
        }
    }

     

















}













