using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Sprite[] inventoryImg;
    Image targetImg;
	// Use this for initialization
	void Start () {
        GameObject.Find("Player");
        targetImg = GetComponent<Image>();
	}

//Update is called once per frame

void Update () {
if (Player.hasItemScarf)
        {
            targetImg.sprite = inventoryImg[0];
        }
        else if (Player.hasItemknive)
      {
            targetImg.sprite = inventoryImg[1];
        }
        else if (Player.hasItemBattery)
      {
            targetImg.sprite = inventoryImg[2];
        }
      else
     {
        }
  }
}