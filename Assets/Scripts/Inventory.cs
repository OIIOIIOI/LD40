using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Sprite[] inventoryImg;
    Image targetImg;
    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        targetImg = GetComponent<Image>();
    }
    
    void Update()
    {
        if (player.HasItem("scarf"))
        {
            targetImg.sprite = inventoryImg[0];
        }
        else if (player.HasItem("knife"))
        {
            targetImg.sprite = inventoryImg[1];
        }
        else if (player.HasItem("battery"))
        {
            targetImg.sprite = inventoryImg[2];
        }
        else
        {
            targetImg.sprite = inventoryImg[3];
        }
    }
}