using UnityEditor.Tilemaps;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //float prevHoriz = 0;
    //float prevVert = 0;
    public float speed = 5;
    public float runSpeedMultiplier = 2;
    public int facingDir = 1; //-1 for facing left
    public Rigidbody2D rb;
    public Animator anim;

    private bool isRunning = false;


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

        if (Input.GetKey(KeyCode.P))
        {
            isRunning = true;
           //rb.linearVelocity = new Vector2(horizontal, vertical) * runSpeed;
        }
        else
        {
            isRunning = false;
        }
    
        float newSpeed = speed;
     
        if(isRunning == true)
        {
            newSpeed = speed * runSpeedMultiplier;
        }
        
            rb.linearVelocity = new Vector2(horizontal, vertical) * newSpeed;
        
        
    }

    void Flip() {
        facingDir *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
