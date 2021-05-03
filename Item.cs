using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour, IInventoryItem
{
    public string _name = "item";
    public Sprite _image = null;

    public Vector3 PickPosition;
    public Vector3 PickRotations;

    Player_CTRL playerHP;

    public void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_CTRL>();
    }

    public string Name
    {
        get { return _name; }
    }

    public Sprite Image
    {
        get { return _image; }
    }

    public InventorySlot Slot
    {
        get;
        set;
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnUse()
    {
        if (Name == "Health")
        {
            if (playerHP.HP == 3)
            {
                NotUse();
            }
            else if (playerHP.HP == 2)
            {
                playerHP.HP += 1;
                playerHP.HP_Player[0].SetActive(true);
            }
            else if (playerHP.HP == 1)
            {
                playerHP.HP += 1;
                playerHP.HP_Player[1].SetActive(true);
            }
        }

        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotations;
    }

    void NotUse()
    {
        print("Full Health");
    }
}
