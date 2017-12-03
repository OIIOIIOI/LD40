using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : MonoBehaviour
{

    public int radius;
    public GameObject iconPrefab;
    public bool givesObject = false;
    public string objectName;

    GameObject[] gremlinsColliders;
    GameObject icon;
    GameObject player;

    GameObject interactiveArea;
    
    protected void Awake () {
        interactiveArea = new GameObject("InteractiveArea");
        interactiveArea.transform.SetParent(gameObject.transform, false);

        player = GameObject.FindGameObjectWithTag("Player");

        CircleCollider2D collider = interactiveArea.AddComponent<CircleCollider2D>();
        collider.radius = radius / 10f;
        collider.offset = new Vector2();
        collider.isTrigger = true;
    }

    private void Start()
    {
        gremlinsColliders = GameObject.FindGameObjectsWithTag("detectedZone");
    }


    public void showIcon()
    {
        if (icon != null)
            return;

        icon = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        icon.transform.SetParent(gameObject.transform, false);
    }

    public void hideIcon ()
    {
        if (icon == null)
            return;

        Destroy(icon);
        icon = null;
    }

    public virtual void Interact ()
    {
        if(player.GetComponent<Player>().HasItem("battery"))
        {
            foreach (GameObject gremlinsCollider in gremlinsColliders)
            {
                gremlinsCollider.transform.parent.transform.Find("Graph").GetComponent<Animator>().SetBool("playerNearby", true);
            }
        }
    }

}
