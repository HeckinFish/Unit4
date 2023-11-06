using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    private Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    private bool isOnGround = true;
    public float horizontalInput;

    public bool hasPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * moveSpeed * horizontalInput, ForceMode2D.Force);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp )
        {
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup")) 
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
