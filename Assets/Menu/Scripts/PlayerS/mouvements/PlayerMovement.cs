using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//tutoriel utilisé : https://www.youtube.com/watch?v=_QajrabyTJc


public class PlayerMovement : MonoBehaviour
{
    public GameObject inventory;

    public OxygenBar oxygene;


    public CharacterController controller;

    public float speed = 35f;


    //gravity
    public float gravity = -9.81f;
    Vector3 velocity;

    //jump
    public float jumpHeight = 3f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    PhotonView view;
    public GameObject cam;
    
    public GameObject radarCam;

    public void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            Destroy(cam);
            Destroy(inventory);
        }
        if (view.IsMine)
        {
            radarCam.SetActive(true);
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (view.IsMine && oxygene.HealthBarBlue.fillAmount > 0)
        {


            //move
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            //move
            Vector3 move = transform.right * x + transform.forward * z;


            controller.Move(move * speed * Time.deltaTime);


            

            //jumping
            if (Input.GetKey("space") && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            
        }
        //gravity
        velocity.y += gravity* Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}