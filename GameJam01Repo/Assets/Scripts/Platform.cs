using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {

            foreach (ContactPoint2D contact in collision.contacts)
            {
                Vector2 sideCheck = contact.normal;
                if ((sideCheck == Vector2.up))
                {
                   //Debug.Log("hit top");
                    
                }
                else if((sideCheck == Vector2.down))
                {
                   //Debug.Log("hit bottom");
                }
                else if ((sideCheck == Vector2.left))
                {
                    //Debug.Log("hit left");
                    player.enableJump();
                }
                else if ((sideCheck == Vector2.right))
                {
                   // Debug.Log("hit right");
                    player.enableJump();
                }
            }

        }
    }
}
