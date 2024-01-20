using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource audioSource;
    
    Rigidbody2D body;
    float inputHorizontal;
    int dirGravity = 1;
    
    public bool canjump = false;
    public float speed = 1.0f;
    public float jumpHeight = 100.0f ;
    public AudioClip death, jump;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
      
        if ((Input.GetButtonDown("Jump") || (Input.GetAxis("Jump") > 0)) && canjump)
        {

            body.velocity = new Vector2(body.velocity.x, jumpHeight * dirGravity);
            canjump = false;
            PlayeAudio(jump);
        }
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2(inputHorizontal * speed, body.velocity.y);
    }
    
    public void enableJump()
    {
        canjump = true;
    }
    public void flipGravity()
    {
        body.gravityScale = -body.gravityScale;
        dirGravity = -dirGravity;
    }
    public void PlayeAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
