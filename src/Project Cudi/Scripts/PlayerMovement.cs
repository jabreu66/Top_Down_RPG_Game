using UnityEditor.Tilemaps;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //float prevHoriz = 0;
    //float prevVert = 0;
    public float speed = 5;
    public int facingDir = 1; //-1 for facing left
    public Rigidbody2D rb;
    public Animator anim;


    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if ((horizontal > 0 && transform.localScale.x < 0) ||
            (horizontal < 0 && transform.localScale.x > 0)) {
                Flip();
            }

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }

    void Flip() {
        facingDir *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
