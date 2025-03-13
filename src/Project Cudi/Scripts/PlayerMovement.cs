using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);
        if (horizontal != 0 || vertical != 0) {
            anim.SetBool("moving", true);
        }
        else {
            anim.SetBool("moving", false);
        }

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }
}
