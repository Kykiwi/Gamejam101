using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource audioSource;
    BoxCollider2D coll;
    Animator anim;    
    Rigidbody2D body;
    SpriteRenderer sprite;
    float inputHorizontal;
    int dirGravity = 1;
    
    public bool canjump = false;
    public float speed = 1.0f;
    public float jumpHeight = 100.0f ;
    public AudioClip jump;
    enum MoveState { idel, running, jumping,falling}

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        sprite = GetComponent <SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
       
        if ((Input.GetButtonDown("Jump") || (Input.GetAxis("Jump") > 0)) && (IsGrounded()|| canjump))
        {

            body.velocity = new Vector2(body.velocity.x, jumpHeight * dirGravity);
            canjump = false;
            PlayeAudio(jump);
        }
        UpdateAnimation();
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2(inputHorizontal * speed, body.velocity.y);
    }
    
    public void enableJump()// enables jumps so outside object allow you to jump like colliding with  a wall
    {
        canjump = true;
    }
    public void flipGravity()// flips gravity when called
    {
        body.gravityScale = -body.gravityScale;
        dirGravity = -dirGravity;
    }
    public void PlayeAudio(AudioClip clip)// plays audio clip 
    {
        audioSource.PlayOneShot(clip);
    }

    private bool IsGrounded()//checks in player is grounded
    {
        
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down * dirGravity, 0.1f, LayerMask.GetMask("Platforms"));
    }
    
    private void UpdateAnimation()
    {
        MoveState state = MoveState.idel;

        if (dirGravity < 0) // checking if sprite needs to be flipped according to gravity for it to look upside down
        {
            sprite.flipY = true;
        }
        else if (dirGravity > 0)
        {
            sprite.flipY = false;
        }

        if (Mathf.Abs(inputHorizontal) > 0f && IsGrounded()) // checking if player is ground and moving to play walking animation
        {
            if(inputHorizontal < 0f) //checking the direction
            {
                sprite.flipX = true;
            }
            else if(inputHorizontal > 0f) 
            {
                sprite.flipX = false;
            }
            state = MoveState.running; //set the walking animation
        }
        else if (inputHorizontal == 0f && IsGrounded())// if not moving and grounded play idel animation
        {
            state = MoveState.idel; //set the idel animations
        }

        if (body.velocity.y > 0.01f)//check if is jumping and not on the ground
        {
            state = MoveState.jumping;//set the jumping animation
        }
        // else if (body.velocity.y < -0.1f)  checking for falling state
        //{
        // state = MoveState.falling;
        // }
        anim.SetInteger("state", (int)state);

    }


}
