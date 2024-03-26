using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{
    public List<ItemBase> itemBaseList = new List<ItemBase>();

    // Adds an ItemBase to the inventory
    public void AddItemBase(ItemBase itemBase)
    {
        if (itemBase != null)
        {
            itemBaseList.Add(itemBase);
            // Optional: Trigger some UI update or event to reflect the inventory change
            OnItemBaseAdded(itemBase);
        }
    }

    // Removes an ItemBase from the inventory
    public bool RemoveItemBase(ItemBase itemBase)
    {
        if (itemBase != null && itemBaseList.Contains(itemBase))
        {
            itemBaseList.Remove(itemBase);
            // Optional: Trigger some UI update or event to reflect the inventory change
            OnItemBaseRemoved(itemBase);
            return true;
        }
        return false;
    }

    // Uses an ItemBase. This method should be adapted based on how ItemBases affect the game (e.g., consumables, equipment)
    public void UseItemBase(ItemBase itemBase)
    {
        if (itemBase != null && itemBaseList.Contains(itemBase))
        {
            // Implement the logic for using the ItemBase here. This could involve applying effects, changing stats, etc.
            itemBase.Use();

            // Optional: If the ItemBase should be removed after use, call RemoveItemBase here
            // RemoveItemBase(ItemBase);

            // Optional: Trigger some UI update or event to reflect the ItemBase usage
            OnItemBaseUsed(itemBase);
        }
    }

    // Optional: Implement this method to handle logic when an ItemBase is added to the inventory
    protected virtual void OnItemBaseAdded(ItemBase itemBase)
    {
        // Example: Update the inventory UI or log the addition
    }

    // Optional: Implement this method to handle logic when an ItemBase is removed from the inventory
    protected virtual void OnItemBaseRemoved(ItemBase itemBase)
    {
        // Example: Update the inventory UI or log the removal
    }

    // Optional: Implement this method to handle logic when an ItemBase is used
    protected virtual void OnItemBaseUsed(ItemBase itemBase)
    {
        // Example: Update the inventory UI, apply effects, or log the usage
    }
}