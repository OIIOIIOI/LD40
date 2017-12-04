using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuryEntity : MonoBehaviour {

    public int radius;
    public GameObject player;

    GameObject detectedArea;

    void Awake()
    {

        player = GameObject.Find("Player");

        detectedArea = new GameObject("detectedArea");
        detectedArea.transform.SetParent(gameObject.transform, false);

        CircleCollider2D collider = detectedArea.AddComponent<CircleCollider2D>();
        collider.radius = radius / 10f;
        collider.offset = new Vector2();
        collider.isTrigger = true;
    }

    private void Start()
    {
        detectedArea.tag = "detectedZone";
    }
}
