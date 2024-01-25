using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] GameObject reactText;
    Animator ani;
    Rigidbody2D body;
    private void Start()
    {
        reactText.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            PlayerDeath();    
        }
    }
    void PlayerDeath()
    {
        // change animation, sound physics if needed
        reactText.SetActive(true);
        body.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");
       
    }
    void ResetLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
