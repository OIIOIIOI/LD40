using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector2 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, v);
        
        movement = movement.normalized * speed * Time.deltaTime;
        
        playerRigidbody.MovePosition(playerRigidbody.position + movement);
    }
}