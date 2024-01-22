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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
