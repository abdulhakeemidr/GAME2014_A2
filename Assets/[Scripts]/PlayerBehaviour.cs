using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;

    public Joystick joystick;
    private Rigidbody2D rigidbody;
    private Vector2 joystickMoveDir;

    void Start()
    {
        joystick = FindObjectOfType<VariableJoystick>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        //Debug.Log("Player speed up : " + rigidbody.velocity.y);
    }

    private void Move()
    {
        MoveTouchInput();
        float deltaTime = Time.deltaTime;

        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        //float jump = Input.GetAxisRaw("Jump");
        Debug.Log(x);
        //Flip Animation
        FlipAnimation(x);


        Vector2 worldTouch = new Vector2();
        foreach(var touch in Input.touches)
        {
            worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
        }

        float horizontalMoveForce = x * horizontalForce * deltaTime;

        rigidbody.AddForce(Vector2.right * horizontalMoveForce);
    }

    void MoveTouchInput()
    {
        joystickMoveDir = new Vector2(joystick.Horizontal, 0.0f);
    }

    private float FlipAnimation(float x)
    {
        x = (x >= 0) ? transform.localScale.x : -transform.localScale.x;

        transform.localScale = new Vector3(x, transform.localScale.y);

        return x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Platform Collision");
            rigidbody.velocity = new Vector2(0f, 0f);
            rigidbody.AddForce(Vector2.up * verticalForce);
        }

        if(collision.gameObject.tag == "DeathPlane")
        {
            Debug.Log("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
