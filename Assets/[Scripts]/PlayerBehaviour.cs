using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;


    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        //Debug.Log("Player speed up : " + rigidbody.velocity.y);
    }

    private void Move()
    {
        float deltaTime = Time.deltaTime;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");

        Vector2 worldTouch = new Vector2();
        foreach(var touch in Input.touches)
        {
            worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
        }

        float horizontalMoveForce = x * horizontalForce * deltaTime;

        rigidbody.AddForce(Vector2.right * horizontalMoveForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Platform Collision");
            rigidbody.velocity = new Vector2(0f, 0f);
            rigidbody.AddForce(Vector2.up * verticalForce);
        }
    }
}
