using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    InventorySlot Slot { get; set; }

    void OnPickup();
    void OnUse();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}

