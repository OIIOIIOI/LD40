using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player: MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector2 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
    List<GameObject> colliding;
    GameObject closest;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        colliding = new List<GameObject>();
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        while (colliding.Contains(collider.gameObject))
            colliding.Remove(collider.gameObject);
        colliding.Add(collider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        while (colliding.Contains(collider.gameObject))
            colliding.Remove(collider.gameObject);

        collider.GetComponentInParent<InteractableEntity>().hideIcon();
    }

    void UpdateClosest ()
    {
        float dist = -1;

        foreach (GameObject go in colliding)
        {
            float temp = Vector3.Distance(go.transform.position, gameObject.transform.position);
            if (temp < dist || dist == -1)
            {
                closest = go.transform.parent.gameObject;
                dist = temp;
            }
        }
    }

    private void Update()
    {
        UpdateClosest();

        if (colliding.Count > 0)
        {
            if (Input.GetAxis("Action") == 1)
                closest.GetComponent<InteractableEntity>().Interact();
        }

        foreach (GameObject go in colliding)
        {
            if (go.transform.parent.gameObject == closest)
                go.GetComponentInParent<InteractableEntity>().showIcon();
            else
                go.GetComponentInParent<InteractableEntity>().hideIcon();
        }
    }

}