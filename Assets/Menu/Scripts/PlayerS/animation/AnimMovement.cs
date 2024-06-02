using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public class AnimMovement : MonoBehaviour
{
    public OxygenBar oxygenInfo;


    Animator animator;
    int avanceHash;
    int reculeHash;
    int jumpHash;
    int danseHash;
    PhotonView view;

    /*
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    */


    //Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        avanceHash = Animator.StringToHash("avance");
        reculeHash = Animator.StringToHash("recule");
        jumpHash = Animator.StringToHash("jump");
        danseHash = Animator.StringToHash("danse");
        view = GetComponent<PhotonView>();
    }

    //Update is called once per frame
    void Update()
    {
        bool avance = animator.GetBool(avanceHash);
        bool recule = animator.GetBool(reculeHash);
        bool saute = animator.GetBool(jumpHash);
        bool danse = animator.GetBool(danseHash);



        bool toucheAvance = Input.GetKey("up");
        bool toucheRecule = Input.GetKey("down");
        bool toucheSaute = Input.GetKey("space");
        bool toucheDanse = Input.GetKey("m");

        bool wantJump = false;


        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        /*
        if (toucheSaute) //si on appuit sur sauter : on veut sauter
            wantJump = true;

        if (wantJump)  //tant qu'on veut sauter : demander l'autorisation
            animator.SetBool("jump", toucheSaute);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && wantJump)  //si perso en train de sauter, arrêter de vouloir sauter
            wantJump = false;
        */
        if (view.IsMine)
        {
            animator.SetBool("jump", toucheSaute);
            animator.SetBool("danse", toucheDanse); //met la valeur bouléenne correspondante à l'anim "danse"
            animator.SetBool("avance", toucheAvance);
            animator.SetBool("recule", toucheRecule);
        }

        if (oxygenInfo.HealthBarBlue.fillAmount <= 0)
        {
            animator.SetBool("death", true);
        }

    }
}
