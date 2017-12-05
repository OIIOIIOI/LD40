using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    GameObject playerGO;
    Transform enemy;

    public float speed;
    public float visionDistance;

    void Start()
    {
        playerGO = GameObject.Find("Player");
        player = playerGO.transform;
        speed = Random.Range(speed, playerGO.GetComponent<Player>().speed*0.5f);
    }

    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < visionDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}