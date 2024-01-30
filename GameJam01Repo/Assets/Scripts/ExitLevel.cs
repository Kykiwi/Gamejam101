using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private AudioSource portalSound;
    
    Animator anim;
    [SerializeField] GameObject exitLevelReact;
    private void Start()
    {
        anim = GetComponent<Animator>();
       
        portalSound = GetComponent<AudioSource>();
        exitLevelReact.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
         if(player != null)
        {

            portalSound.Play();
            exitLevelReact.SetActive(true);
            anim.SetTrigger("Tele");
        }
    }
    void NextLevel()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
