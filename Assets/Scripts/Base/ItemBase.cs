using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // Unique identifier for the item
    public string itemId;

    // Display name of the item
    public string itemName;

    // Description of the item
    public string description;

    // Item type can be an enum or string depending on your needs, such as "Weapon", "Consumable", etc.
    public string itemType;

    // Optional: Item icon for UI representation
    public Sprite icon;

    // The base amount for how many of this item can exist in a single inventory slot
    public int stackSize = 1;

    // Use this method to define what happens when the item is used
    // For example, a consumable might be consumed to restore health or grant a temporary buff
    public virtual void Use()
    {
        // Implement the effect of using the item here
        // Note: You might want to pass in additional parameters such as the user of the item
    }

    // Optional: Override this for a more detailed behavior when the item is added to an inventory
    public virtual void OnAddedToInventory()
    {
        // Logic for when the item is added to an inventory, such as updating UI or player stats
    }

    // Optional: Override this for behavior when the item is removed from an inventory
    public virtual void OnRemovedFromInventory()
    {
        // Logic for when the item is removed from an inventory, such as updating UI or player stats
    }

    // Additional methods can be defined here based on your game's requirements,
    // such as methods for equipping the item, inspecting it for more details, or trading it.
}