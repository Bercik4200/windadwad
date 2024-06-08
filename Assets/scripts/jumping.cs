using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool canJump = false;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask mask;
    public AudioClip jumpSound; // Dodaj zmienną do przechowywania dźwięku skoku
    private AudioSource audioSource; // Dodaj zmienną do komponentu AudioSource


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 2f, mask);
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound); // Funkcja do odtwarzania dźwięku skoku
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
}
