using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip landingSound;
    public float speed = 60;
    public float jumpingSpeed = 50;

    void Update()
    {
        Vector2 velocity = rigidbody2D.velocity;
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(velocity.y) < 1)
        {
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
            velocity.y = jumpingSpeed;
        }
        rigidbody2D.velocity = velocity;
    }

    void FixedUpdate()
    {
        float dx = 0.0f;
        bool leftPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool rightPressed = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        if (leftPressed) dx--;
        if (rightPressed) dx++;

        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = dx * speed;

        rigidbody2D.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (rigidbody2D.velocity.y == 0)
        {
            AudioSource.PlayClipAtPoint(landingSound, Camera.main.transform.position);
        }
    }
}
