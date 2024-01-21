using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 1.0f;
    public float timeMove = 2.0f;
    public bool vertical;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timer = timeMove;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = timeMove;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = body.position;

        if (vertical)
        {

            position.y = position.y + Time.deltaTime * speed * direction; ;

        }
        else
        {

            position.x = position.x + Time.deltaTime * speed * direction; ;
        }

        body.MovePosition(position);

    }
}
