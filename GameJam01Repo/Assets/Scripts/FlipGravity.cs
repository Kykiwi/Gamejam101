using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipgravity : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.flipGravity();
            Destroy(gameObject);

        }
    }
}
