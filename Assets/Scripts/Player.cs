using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player: MonoBehaviour
{

    public float speed = 6f;
    public bool hasItemScarf = false;
    public bool hasItemBattery = false;
    public bool hasItemKnife = false;

    bool isFacingRight;
    Vector2 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
    List<GameObject> colliding;
    GameObject closest;
    Transform player;

    GameObject[] gremlinsColliders;

    void Awake()
    {
        player = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        colliding = new List<GameObject>();
        //PlayerPrefs.SetString("nextRun", "nextRun");
    }

    private void Start()
    {
        gremlinsColliders = GameObject.FindGameObjectsWithTag("detectedZone");
    }

    void FixedUpdate()
    {
        Flip();

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "detectedZone") 
        {
            other.gameObject.transform.parent.transform.Find("Graph").GetComponent<Animator>().SetBool("playerNearby", true);
            //other.gameObject.transform.parent.GetComponent<Animator>().SetBool("playerNearby", true);
            //other.gameObject.transform.parent.localScale -= new Vector3(0, 3f / 2f, 0);
        }
        else
        {
            while (colliding.Contains(other.gameObject))
                colliding.Remove(other.gameObject);
            colliding.Add(other.gameObject);
        }  
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "detectedZone")
        {
            other.gameObject.transform.parent.transform.Find("Graph").GetComponent<Animator>().SetBool("playerNearby", false);
            //other.gameObject.transform.parent.GetComponent<Animator>().SetBool("playerNearby", false);
        }
        else
        {
            while (colliding.Contains(other.gameObject))
                colliding.Remove(other.gameObject);

            other.GetComponentInParent<InteractableEntity>().hideIcon();
        }     
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
            if (Input.GetKeyUp("space"))
            {
                closest.GetComponent<InteractableEntity>().Interact();
            }
        }

        foreach (GameObject go in colliding)
        {
            if (go.transform.parent.gameObject == closest)
                go.GetComponentInParent<InteractableEntity>().showIcon();
            else
                go.GetComponentInParent<InteractableEntity>().hideIcon();
        }
    }

    public bool HasItem (string name)
    {
        switch (name)
        {
            case "scarf":
                return hasItemScarf;
            case "battery":
                return hasItemBattery;
            case "knife":
                return hasItemKnife;
            default:
                return false;
        }
    }

    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            player.GetComponent<SpriteRenderer>().flipX = true;


        if (Input.GetAxisRaw("Horizontal") < 0)
            player.GetComponent<SpriteRenderer>().flipX = false;
    }

}