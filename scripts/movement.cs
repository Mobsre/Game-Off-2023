using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public CharacterController controller;
    public Transform gunposition;
    
    public float speed = 50f;
    public float gravity;
    public float jumpheight;

    public bool namen = true;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform gun;

    //small 
    public float smallspeed;
    public float crouchYscale;
    private float startYscale;
    public KeyCode crouchKey = KeyCode.LeftControl;



    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }

        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(crouchYscale, crouchYscale, crouchYscale);
            speed = 18.75f;
            jumpheight = jumpheight / 2.5f;
            namen = false;
        }

        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed = 7.5f;
            jumpheight = jumpheight * 2.5f;
            namen = true;
        }

        if(namen == false)
        {
            gun.transform.position = new Vector3(gun.transform.position.x + 500, gun.transform.position.y, gun.transform.position.z);
        }
        if(namen == true)
        {
            gun.transform.position = gunposition.transform.position;
        }



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
