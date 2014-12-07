using UnityEngine;
using System.Collections;

public class ScrollUp : MonoBehaviour
{
    public float initialSpeed = 25.0f;
    public float maxSpeed = 50.0f;
    public float acceleration = 0.01f;

    public float speed;

    void Start()
    {
        speed = initialSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.up * -speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        speed = Mathf.Min(maxSpeed, speed + acceleration);
    }
}
