using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    //RB
    private Rigidbody2D rb;

    //Input
    public float jumpForce;
    public float moveSpeed;
    private float powerupStrength = 15.0f;
    public float horizontalInput;

    //Ground check
    private bool isOnGround = true;

    //Powerup
    public bool hasPowerUp;
    public GameObject powerupIndicator;

    //Audio
    public AudioClip hitSound;
    public AudioClip blastAway;
    private AudioSource playerAudio;
    public AudioClip powerupSound;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * moveSpeed * horizontalInput, ForceMode2D.Force);
        
    }

    private void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0, 0);
        powerupIndicator.transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 0.7f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(hitSound, 1.0f);
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp )
        {
            Rigidbody2D eRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
            eRb.AddForce(awayFromPlayer * powerupStrength, ForceMode2D.Impulse);

            playerAudio.PlayOneShot(blastAway, 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup")) 
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
            powerupIndicator.gameObject.SetActive(true);
            playerAudio.PlayOneShot(powerupSound, 1.0f);
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
