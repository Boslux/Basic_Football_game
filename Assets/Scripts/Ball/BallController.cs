using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [Header("Comp")]
    Rigidbody2D rb;
    public ScoreController sc;

    [Header("Val")]
    [SerializeField] private float force;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ShootController(Vector3 direction)
    {
        rb.AddForce(direction*force*Time.deltaTime*500);
    }

    void Goal()
    {
        SceneManager.LoadScene(1);
        if (sc.scoreP1==5||sc.scoreP2==5)    
        {
            sc.scoreP2 = 0;
            sc.scoreP1 = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Goal"))
        {
            Invoke("Goal", 3.5f);
            sc.scoreP2++;
        }
        if (cls.gameObject.CompareTag("GoalP2"))
        {
            Invoke("Goal", 3.5f);
            sc.scoreP1++;
        }
    }
}
