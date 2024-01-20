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
           // foreach (ContactPoint2D contact in collision.contacts)
            //{
              //  Vector2 sideCheck = contact.normal;
             //   if (!(sideCheck == Vector2.up))
              //  {
               //     Debug.Log("able to jump");
                    player.enableJump();
               // }
               // else
               // {
               //     Debug.Log("hit bottom of block");
               // }
            //}
                
        }
    }
}
