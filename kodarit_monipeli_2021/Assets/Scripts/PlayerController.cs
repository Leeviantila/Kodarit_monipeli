using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();

        Move();

    }

    void CheckIfGrounded(){
        //Funktio tarkistaa onko pelaaja maassa

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

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

        // Toteuttaa if - else rakenteen (boolean muoto)
        float targetSpeed = Input.GetButton("Fire1") ? runSpeed : moveSpeed;

        MoveDir = transform.right * xAxis + transform.forward * zAxis;

        if(MoveDir == Vector3.zero){
            targetSpeed = 0;
        }

        controller.Move(MoveDir * targetSpeed * Time.deltaTime);




    }



}
