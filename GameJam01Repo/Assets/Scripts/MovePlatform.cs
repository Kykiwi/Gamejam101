using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    public float speed = 1.0f;
    int index = 0;

    void FixedUpdate()
    {
        if (Vector2.Distance(waypoints[index].transform.position,transform.position)< 0.1f)
        {
            index++;
            if(index>= waypoints.Length)
            {
                index = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * speed);
       
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    collision.gameObject.transform.SetParent(transform);
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    collision.gameObject.transform.SetParent(null);
    //}

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
                    collision.gameObject.transform.SetParent(transform);

                }
                else if ((sideCheck == Vector2.down))
                {
                    //Debug.Log("hit bottom");
                    collision.gameObject.transform.SetParent(transform);
                }
                else if ((sideCheck == Vector2.left))
                {
                    //Debug.Log("hit left");
                    
                }
                else if ((sideCheck == Vector2.right))
                {
                    // Debug.Log("hit right");
                    
                }
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
