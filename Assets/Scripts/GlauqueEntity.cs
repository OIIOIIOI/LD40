using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlauqueEntity : MonoBehaviour
{

    public Sprite[] steps;
    
	void Awake ()
    {
		if (steps.Length > 1)
        {
            RunSettings settings = GameObject.Find("Scripts").GetComponent<RunSettings>();
            int step = 0;

            if (settings.glauqueLevel > 0)
            {
                step = settings.glauqueLevel - 1;
                if (Random.value < settings.glauqueRatio)
                    step = settings.glauqueLevel;
            }

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sprite = steps[step];
            //sr.flipX = Random.value > 0.5f;
            transform.localScale = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.8f, 1.1f), 1f);
        }
	}
}
