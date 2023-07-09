using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefenseGun : Gun
{
    [SerializeField] private float speed, throwingForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isActive = false;
    private Transform enemyTransform;
    private Transform vectorStart, gunPoint;
    private Vector2[] points = new Vector2[4];
    private float y = 0;

    // set direction position rotation
    private void Start()
    {
        enemyTransform = GameObject.Find("Enemy").transform;
        vectorStart = GameObject.Find("VectorStart").transform;
        gunPoint = GameObject.Find("GunPoint").transform;
        Vector2 direction = (Vector2)gunPoint.position - (Vector2)vectorStart.position;
        transform.position = gunPoint.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        rb.AddForce(direction * throwingForce, ForceMode2D.Impulse);
        StartCoroutine(WaitCoroutine());
    }
    void Update()
    {
        if (isActive)
        {
            y = Mathf.MoveTowards(y, 1, 1.5f * Time.deltaTime);
            MoveBezier(y);
        }
    }

    private void MoveBezier(float t)
    {
        transform.position = Bezier.GetPoint(points[0], points[1], points[2], enemyTransform.position, t);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Bezier.GetFirstDerivative(points[0], points[1], points[2], enemyTransform.position, t));
    }
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        SetPoints();
        isActive = true;
    }
    private void SetPoints()
    {
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(position.x > gunPoint.position.x ? transform.right.x : -transform.right.x, transform.up.y);
        points[0] = position;
        points[1] = position + direction * 3;
        points[2] = new Vector2(Random.Range(points[1].x, enemyTransform.position.x), Random.Range(points[1].y - 5, enemyTransform.position.y + 5));

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
