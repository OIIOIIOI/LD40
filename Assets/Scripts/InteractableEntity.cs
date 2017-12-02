using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : MonoBehaviour {

    public int radius;
    public GameObject iconPrefab;
    GameObject icon;

    GameObject interactiveArea;
    
    void Awake () {
        interactiveArea = new GameObject("InteractiveArea");
        interactiveArea.transform.SetParent(gameObject.transform, false);

        CircleCollider2D collider = interactiveArea.AddComponent<CircleCollider2D>();
        collider.radius = radius / 10f;
        collider.offset = new Vector2();
        collider.isTrigger = true;
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

    void Update () {
		
	}
}
