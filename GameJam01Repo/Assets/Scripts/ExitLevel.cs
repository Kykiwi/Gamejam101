using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public AudioClip clip;

    [SerializeField] GameObject exitLevel;
    private void Start()
    {
        exitLevel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
         if(player != null)
        {
            player.PlayeAudio(clip);
            exitLevel.SetActive(true);
            NextLevel();
        }
    }
    void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
