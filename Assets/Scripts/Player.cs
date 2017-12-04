using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player: MonoBehaviour
{

    public float speed = 6f;
    public float slowSpeedPanalty = 3f;
    public DialogInteractableEntity scarfNPC;

    bool isFacingRight;
    float initialSpeed;
    Vector2 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.
    List<GameObject> colliding;
    GameObject closest;
    Transform player;
    bool canSkipDialog = true;
    bool hasItemScarf = false;
    bool hasItemBattery = false;
    bool hasItemKnife = false;

    GameObject[] gremlinsColliders;

    void Awake()
    {
        player = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        colliding = new List<GameObject>();
        initialSpeed = speed;
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

        GameObject dialogCanvas = GameObject.Find("DialogueCanvas");
        if (dialogCanvas.transform.Find("Image").gameObject.activeInHierarchy)
            return;

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
        if(other.gameObject.tag == "enemy")
        {
            SlowSpeed();
        }
        else
        {
            if (other.gameObject.tag == "detectedZone")
            {
                other.gameObject.transform.parent.transform.Find("Graph").GetComponent<Animator>().SetBool("playerNearby", true);
            }
            else
            {
                while (colliding.Contains(other.gameObject))
                    colliding.Remove(other.gameObject);
                colliding.Add(other.gameObject);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            IntialSpeed();
        }
        else
        {
            if (other.gameObject.tag == "detectedZone")
            {
                other.gameObject.transform.parent.transform.Find("Graph").GetComponent<Animator>().SetBool("playerNearby", false);
            }
            else
            {
                while (colliding.Contains(other.gameObject))
                    colliding.Remove(other.gameObject);

                other.GetComponentInParent<InteractableEntity>().HideIcon();
            }
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
                //if (!canSkipDialog)
                //    return;
                //StartCoroutine(Wait());
            }
        }

        foreach (GameObject go in colliding)
        {
            if (go.transform.parent.gameObject == closest)
                go.GetComponentInParent<InteractableEntity>().ShowIcon();
            else
                go.GetComponentInParent<InteractableEntity>().HideIcon();
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

    public void AddItem(string name)
    {
        switch (name)
        {
            case "scarf":
                hasItemScarf = true;
                scarfNPC.NextDialog();
                break;
            case "battery":
                hasItemBattery = true;
                break;
            case "knife":
                hasItemKnife = true;
                break;
            default:
                return;
        }
    }

    public void RemoveItem(string name)
    {
        switch (name)
        {
            case "scarf":
                hasItemScarf = false;
                break;
            case "battery":
                hasItemBattery = false;
                break;
            case "knife":
                hasItemKnife = false;
                break;
            default:
                return;
        }
    }

    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            player.GetComponent<SpriteRenderer>().flipX = true;


        if (Input.GetAxisRaw("Horizontal") < 0)
            player.GetComponent<SpriteRenderer>().flipX = false;
    }

    void SlowSpeed()
    {
        speed = slowSpeedPanalty;
    }

    void IntialSpeed()
    {
        speed = initialSpeed;
    }

    IEnumerator Wait()
    {
        closest.GetComponent<InteractableEntity>().Interact();
        canSkipDialog = false;

        yield return new WaitForSeconds(1);

        canSkipDialog = true;
    }

}