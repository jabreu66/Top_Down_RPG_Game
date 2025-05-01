using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public int facingDir = 1; //-1 for facing left
    public Rigidbody2D rb;
    public Animator anim;
    
    private bool isAttacking = false;
    private bool isKnockedBack = false;

    public Player_Combat player_combat;

    void Update()
    {
        // Process input in Update instead of FixedUpdate for more responsive controls
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking) {
            player_combat.Attack();
            //StartCoroutine(Attack());
        }
    }

    void FixedUpdate()
    {
        if (isKnockedBack == false) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if ((horizontal > 0 && transform.localScale.x < 0) ||
                (horizontal < 0 && transform.localScale.x > 0)) {
                    Flip();
            }

            anim.SetFloat("horizontal", horizontal);
            anim.SetFloat("vertical", vertical);

            // Movement code
            if (!isAttacking) {
                rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
            }
        }
        
    }

    void Flip() {
        facingDir *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator Attack() {
        // Set flags and trigger animation
        isAttacking = true;
        anim.ResetTrigger("walking");
        anim.SetTrigger("attack");
        
        // Wait a small amount of time to ensure the animation has started
        yield return new WaitForSeconds(0.1f);
        
        // Wait for the animation to complete
        // Get the length of the attack animation
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float attackAnimationLength = (stateInfo.length)/2;
        
        // Wait for the animation to finish
        yield return new WaitForSeconds(attackAnimationLength);
        
        // Animation has finished, return to idle state
        isAttacking = false;
        anim.SetTrigger("walking");
        anim.ResetTrigger("attack");
        Debug.Log("Attack animation completed");
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