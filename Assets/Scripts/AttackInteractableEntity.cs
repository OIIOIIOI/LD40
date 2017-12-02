using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInteractableEntity : InteractableEntity {

	public override void Interact () {
        Debug.Log("Attack");
	}

}
