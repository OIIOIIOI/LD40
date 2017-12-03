using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Sprite[] inventoryImg;
    Image targetImg;
    Player player;
	// Use this for initialization
	void Start () {
        player=GameObject.Find("Player").GetComponent<Player>();
        targetImg = GetComponent<Image>();
	}

//Update is called once per frame

void Update () {
if (player.hasItemScarf)
        {
            targetImg.sprite = inventoryImg[0];
        }
        else if (player.hasItemKnife)
      {
            targetImg.sprite = inventoryImg[1];
        }
        else if (player.hasItemBattery)
      {
            targetImg.sprite = inventoryImg[2];
        }
      else
     {
        }
  }
}