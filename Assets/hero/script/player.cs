using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


  //  public GameObject BulletPrefab;
   // float fireDelay = 0.25f;
   // float cooldown = 0;

    // Variables set in the inspector
    public float WalkSpeed = 3;
    public float RunSpeed = 140;
    public float JumpForce = 5000;
    public AudioSource jumpSound;
    Vector2 mFacingDirection;

    // Booleans used to coordinate with the animator's state machine
    bool Running;
    bool Moving;
    bool Grounded;
    bool Falling;
    //bool Shooting;


    //bool shoot = false;
    // bool dead = false;

    // References to other components (can be from other game objects!)
    Animator Animator;
    Animator mAnimator;
    Rigidbody2D RigidBody2D;
    AudioSource mJumpSound;
    AudioSource mdeadSound;
    AudioSource mTaraRara;




    void Start()

    {
        // Get references to other components and game objects
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        mJumpSound = GetComponents<AudioSource>()[0];
        mdeadSound = GetComponents<AudioSource>()[1];
        mTaraRara = GetComponents<AudioSource>()[2];

        mFacingDirection = Vector2.right;


    }

    void Update()
    {
        
        {

            MoveCharacter();
            CheckFalling();
            CheckGrounded();

            // Update animator's variables
            Animator.SetBool("isRunning", Running);
            Animator.SetBool("isMoving", Moving);
            Animator.SetBool("isGrounded", Grounded);
            Animator.SetBool("isFalling", Falling);
           // Animator.SetBool("isShooting", Shooting);
            //Animator.SetBool("dead", dead);
        }

    }



    private void MoveCharacter()
    {


        // Check if we are running or not
        // TODO: Check if the player wants to run (see input manager)
        //       and set the value of "Running" accordingly
        //       Use Input and the intellisence

       

        Running = Input.GetButton("run");


        // Determine movement speed
        float moveSpeed = Running ? RunSpeed : WalkSpeed;
        //Change value    (  IF   )    TRUE    :   FALSE   ;
     // Check for movement
        
        Moving = Input.GetButton("Horizontal"); //returns true or false if pressed.
        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;

        if (direction > 0)
            mFacingDirection = Vector2.right;
        else if (direction < 0)
            mFacingDirection = Vector2.left;
        FaceDirection(mFacingDirection);

       



        // Check if we can jump
        if (Grounded && Input.GetButtonDown("Jump"))
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce);
            if (Input.GetButtonDown("Jump"))
                mJumpSound.Play();
        }
    }


    private void CheckFalling()
   
         {
            Falling = RigidBody2D.velocity.y < 0.0f;
        }
        
    

    private void CheckGrounded()
    {
        Grounded = RigidBody2D.velocity.y == 0.0f;
    }

    public Vector2 GetFacingDirection()
    {
        return mFacingDirection;
    }

    public void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) 
            //Don't change look.
            return;

        // Flip the sprite (NOTE: Vector3.forward is positive Z in 3D. The Sprite is on XY plane!)
        Quaternion rotation3D = direction == Vector2.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;
    }

   


    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "enemy" || Col.gameObject.tag == "cone" )
        {


            mdeadSound.Play();
         
            


        }
    }
}
