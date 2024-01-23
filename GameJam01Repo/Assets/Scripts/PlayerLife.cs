using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        ResetLevel();
    }
    void ResetLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
