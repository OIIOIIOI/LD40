using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    GameObject playerGO;
    Transform enemy;

    public float speed;

    void Start()
    {
        playerGO = GameObject.Find("Player");
        player = playerGO.transform;
        speed = Random.Range(speed, playerGO.GetComponent<Player>().speed);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}