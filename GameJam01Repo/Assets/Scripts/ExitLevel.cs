using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    
    Animator anim;
    [SerializeField] GameObject exitLevelReact;
    private void Start()
    {
        anim = GetComponent<Animator>();
       
        exitLevelReact.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
         if(player != null)
        {
            
            player.PlayeAudio(clip);
            exitLevelReact.SetActive(true);
            anim.SetTrigger("Tele");
        }
    }
    void NextLevel()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
