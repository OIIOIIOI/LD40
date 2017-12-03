using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationOffset : MonoBehaviour
{
    
	void Start () {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.speed = 0.9f + Random.Range(0f, 0.3f);
    }

}
