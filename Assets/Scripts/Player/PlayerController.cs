using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Comp")]
    private Rigidbody2D rb;

    [Header("val")]
    private Vector3 movement;
    public float speed;
    public float radius;
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
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.velocity=movement*speed*100*Time.deltaTime;
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(Collider2D coll in colls)
            {
                if(coll.TryGetComponent(out BallController ball))
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
