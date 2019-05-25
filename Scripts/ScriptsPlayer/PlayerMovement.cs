using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Rigidbody2D rb;
    public float maxSpeed;
    public Animator animator;
    public float jumpForce;
    public bool isJumping;
    public bool facingRight = true;
    public float moveInput;
    public bool checkingWall;
    public float wallJumpForce;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    // use this for initialization
    void Start ()
    {

       rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
	
	// update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
	}

    void FixedUpdate()
    {
        Movement();
        Jump();
        WallJump();
        Dash();
    }

    // makes player walk
    void Movement()
    {
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flipping();
        }
        if (facingRight == true && moveInput < 0)
        {
            Flipping();
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.45f,0.45f,0);
        }

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.45f, 0.45f, 0);
        }

        if (moveInput == 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0);
        }
    }

    // makes player jump
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            animator.SetBool("Jumping", true);
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.y, jumpForce));
        }
    }

    // checks if the player is allowed to jump
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            animator.SetBool("Jumping", false);
            isJumping = false;
        }
        if (col.gameObject.tag == "wallJumpWall")
        {
            animator.SetBool("Wall", true);
            checkingWall = true;
            isJumping = false;
        }
        if (col.gameObject.tag != "wallJumpWall")
        {
            animator.SetBool("Wall", false);
            checkingWall = false;
        }

        if (col.gameObject.tag == "wall")
        {
            animator.SetBool("Wall", true);
        }

    }

    // flips player
    void Flipping()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // enables wall jump
    void WallJump()
    {
        if (checkingWall && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(0,0);
            Debug.Log("hewwo");
            rb.AddForce(Vector2.up * wallJumpForce * Time.deltaTime);
            rb.AddForce(-transform.right * 100 * Time.deltaTime);
            checkingWall = false;
        } 
    }

    void Dash()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }

            if (direction == 1)
            {
                rb.velocity = Vector2.left * dashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
            else if (direction == 3)
            {
                rb.velocity = Vector2.up * dashSpeed;
            }
        }
    }
}
