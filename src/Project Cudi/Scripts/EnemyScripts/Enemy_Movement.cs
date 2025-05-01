using UnityEngine;
using System.Collections;

public class Enemy_Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private bool isChasing;
    private Transform player;
    public Animator anim;
    private bool isKnockedBack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnockedBack == false) {
            if (isChasing == true) {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            if (player == null) {
                player = collision.transform;
            }
            isChasing = true;
            anim.SetBool("chase", true);
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
            anim.SetBool("chase", false);
        }
    }

    public void Knockback(Transform enemy, float force, float stunTime) {
        //disable player movement
        //knock him back
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction*force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
