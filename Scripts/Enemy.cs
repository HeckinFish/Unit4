using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Rigidbody2D eRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        eRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("laughing_crying");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;

        eRb.AddForce(lookDirection * speed);
    }
}
