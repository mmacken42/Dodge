using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 7f;
    public event System.Action OnPlayerDeath;

    private float halfScreenWidthInWorldUnits;
    private float halfPlayerWidth;

    private void Start()
    {
        halfPlayerWidth = transform.localScale.x / 2f;

        halfScreenWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * movementSpeed;

        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x + halfPlayerWidth < -halfScreenWidthInWorldUnits)
        {
            transform.position = new Vector2(halfScreenWidthInWorldUnits + halfPlayerWidth, transform.position.y);
        }

        if (transform.position.x - halfPlayerWidth > halfScreenWidthInWorldUnits)
        {
            transform.position = new Vector2(-halfScreenWidthInWorldUnits - halfPlayerWidth, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }

            Destroy(gameObject);
        }
    }
}
