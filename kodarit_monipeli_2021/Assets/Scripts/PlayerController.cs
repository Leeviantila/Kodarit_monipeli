using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public float moveSpeed = 8f;
    public float runSpeed = 14f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private Vector3 MoveDir;
    PhotonView view;
    public Animator animator;

    [SerializeField] private bool isGround;






    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine){
            
        CheckIfGrounded();
        Move();
        Jump();
            
        }
        
    
    }

    void CheckIfGrounded(){
        //Funktio tarkistaa onko pelaaja maassa

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        animator.SetBool("OnMaassa", isGround);
        

        if(isGround){

            velocity.y = -2;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }

    void Move(){
        //Funktio ohjaa pelaajan liikkumis ominaisuutta.
        
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        MoveDir = transform.right * xAxis + transform.forward * zAxis;

        // Toteuttaa if - else rakenteen (boolean muoto)
        float targetSpeed = Input.GetButton("Fire1") ? runSpeed : moveSpeed;        

        if(MoveDir == Vector3.zero){
            targetSpeed = 0;
        }

        animator.SetFloat("Nopeus", targetSpeed);

        controller.Move(MoveDir * targetSpeed * Time.deltaTime);




    }

    void Jump(){

        if(Input.GetButtonDown("Jump") && isGround){
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

         velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime);

        
        

        

    }


}
