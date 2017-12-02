using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player: MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector2 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
    List<GameObject> colliding;

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

        if (Input.GetAxis("Action") == 1)
        {
            float dist = 9999999;
            GameObject closest = null;

            foreach (GameObject go in colliding)
            {
                float temp = Vector3.Distance(go.transform.position, gameObject.transform.position);
                Debug.Log(temp);
                if (temp < dist)
                {
                    closest = go.transform.parent.gameObject;
                    dist = temp;
                }

            }
            Debug.Log("closest:");
            Debug.Log(closest);
        }
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

    bool IsTheClosest (GameObject target)
    {
        float dist = -1;
        GameObject closest = null;

        foreach (GameObject go in colliding)
        {
            float temp = Vector3.Distance(go.transform.position, gameObject.transform.position);
            if (temp < dist || dist == -1)
            {
                closest = go.transform.parent.gameObject;
                dist = temp;
            }
        }
        return (closest == target);
    }

    private void Update()
    {
        if (colliding.Count > 0)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        else
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;


        foreach (GameObject go in colliding)
        {
            if (IsTheClosest(go.transform.parent.gameObject))
                go.GetComponentInParent<InteractableEntity>().showIcon();
            else
                go.GetComponentInParent<InteractableEntity>().hideIcon();
        }
    }

}