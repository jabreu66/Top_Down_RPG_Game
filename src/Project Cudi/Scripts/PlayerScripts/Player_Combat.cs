using System.Threading;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;

    public float cooldown = 0.5f;
    private float cdtimer;
    public float knockbackForce;
    public float stunTime;

    private void Update()
    {
        if (cdtimer > 0) {
            cdtimer -= Time.deltaTime;
        }

    }

    public void Attack() {
        if (cdtimer <= 0) {
            anim.SetBool("attacking", true);

            
            cdtimer = cooldown;
        }
        
    }

    public void DealDamage() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0) {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-damage);
            enemies[0].GetComponent<Enemy_Movement>().Knockback(transform, knockbackForce, stunTime);
        }
    }

    public void FinishAttacking() {
        anim.SetBool("attacking", false);
    }

    private void OGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
