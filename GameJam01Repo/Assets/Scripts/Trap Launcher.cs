using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class TrapLauncher : MonoBehaviour
{
    [SerializeField] Bullet trap;
    [SerializeField] float speed;
    [SerializeField] float angle;

    Rigidbody2D body;
    [SerializeField] float shotTime;
    float timer;
    Vector2 v1 = Vector2.up;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timer = shotTime;
        
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Launch();
            timer = shotTime;
        }

    }

    private void Launch()
    {
        GameObject projectile = Instantiate(trap.gameObject, body.position, Quaternion.identity);
        Bullet b1 = projectile.GetComponent<Bullet>();
        
        float angleRad = Mathf.Deg2Rad * angle;  // set launch angle based on determined angle 
        Quaternion rot = Quaternion.Euler(0, 0, angle);
        Vector2 direction = rot * v1;

        b1.Launch(direction, speed);
        
    }


}
