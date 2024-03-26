using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [Header("Comp")]
    private Rigidbody2D rb;

    [Header("val")]
    private Vector3 movement;
    public float speed;
    public float radius;

    [Header("Cntrllr")]
    public KeyCode upKey = KeyCode.I; // Yukarı hareket tuşu
    public KeyCode downKey = KeyCode.K; // Aşağı hareket tuşu
    public KeyCode leftKey = KeyCode.J; // Sola hareket tuşu
    public KeyCode rightKey = KeyCode.L; // Sağa hareket tuşu
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
        Shoot();
    }
    void PlayerMovement()
    {
        // Yukarı hareket
        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // Aşağı hareket
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Sola hareket
        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Sağa hareket
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D coll in colls)
            {
                if (coll.TryGetComponent(out BallController ball))
                {
                    Vector3 dir = coll.transform.position - transform.position;
                    ball.ShootController(dir);
                    break;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
