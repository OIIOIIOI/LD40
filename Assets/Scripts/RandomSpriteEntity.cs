using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteEntity : MonoBehaviour {

    public Sprite[] sprites;

    void Awake()
    {
        if (sprites.Length > 1)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sprite = sprites[Random.Range(0, sprites.Length)];
            sr.flipX = Random.value > 0.5f;
            transform.localScale = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.8f, 1.1f), 1f);
        }
    }

}
