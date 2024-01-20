using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidJumpPower : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.enableJump();
            Destroy(gameObject);
        }
    }
}
