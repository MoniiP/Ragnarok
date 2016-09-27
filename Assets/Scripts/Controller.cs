using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public float moveForce = 1f;
<<<<<<< HEAD
    public float maxSpeed = 0.5f;
=======
    public float maxSpeed = 1f;
    public float jumpForce = 25f;
    public Transform groundCheck;
    float lockPos = 0;

>>>>>>> b31f32a4a914af84f7d368955c8fa49ef7f1a360
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    public float jumpSpeed = 0.5f;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime, Space.World);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

<<<<<<< HEAD

=======
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
>>>>>>> b31f32a4a914af84f7d368955c8fa49ef7f1a360
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}