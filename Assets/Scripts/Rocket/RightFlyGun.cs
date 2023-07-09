using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlyGun : Gun
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private Transform vectorStart, gunPoint;
    private Vector2 direction;
   

    // set direction position rotation
    private void Start()
    {
        vectorStart = GameObject.Find("VectorStart").transform;
        gunPoint = GameObject.Find("GunPoint").transform;
        transform.Rotate(Vector3.forward, 90);

        

        direction = (Vector2)gunPoint.position - (Vector2)vectorStart.position;
        transform.position = gunPoint.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;
    }

    // destroying guns when camera does not see it
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("OutOfCamera"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
