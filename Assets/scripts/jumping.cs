using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool canJump = false;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask mask;
    public GameObject deathFX;

    public AudioClip umieram;
    public AudioClip skacze;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DeathCondition();
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 2f, mask);
        Move();
        Jump();
        
        // zmiana kierunku grafiki
        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow))))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            gameObject.GetComponent<AudioSource>().PlayOneShot(skacze);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true; // Allow jumping again when the player lands on a platform
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = false; // Disable jumping when the player leaves the platform
            
        }
    }


    private void DeathCondition()
    {
        // wysoksoc gracza
        if (transform.position.y < -5.3f)
        {
            
            //particle
            Instantiate(deathFX, transform.position, quaternion.identity);
            
            // audio
            gameObject.GetComponent<AudioSource>().PlayOneShot(umieram);

            //umrzyj
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }


        }
    }
}
