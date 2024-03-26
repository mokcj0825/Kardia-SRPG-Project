using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : EntityBase
{
    public int movementRange;
    public int actionPoints;

    // Additional attributes for unit-specific behaviors, such as attack power, defense, etc.
    // public int attackPower; // This could also be inherited from EntityBase if defined there

    // Start is used for initialization
    protected override void Start()
    {
        base.Start(); // Call to the base start method for any generic initialization from EntityBase
    }

    // Method to move the unit to a new position
    public void Move(Vector2 newPosition)
    {
        // Implement movement logic here, checking if the move is within range and not blocked
        // This might involve pathfinding logic to determine a valid path and updating the unit's position

        // After moving, you may want to deduct action points or perform other updates
        actionPoints--; // Example: Decrement action points after moving
    }

    // Method for the unit to perform an action, like attacking
    public virtual void PerformAction(UnitBase target)
    {
        // Implement action logic here, such as attacking another unit
        // This might involve checking if the target is within range, calculating damage, etc.

        // Example: target.TakeDamage(attackPower); // Assuming TakeDamage and attackPower are defined
        // After performing an action, deduct appropriate action points or handle other consequences
    }

    // Method to refresh the unit's state for a new turn or phase
    public void RefreshForNewTurn()
    {
        // Reset the unit's action points or perform other necessary reset logic for a new turn
        /*actionPoints =  some maximum value or formula ;*/
    }

    // Additional unit-specific methods can be added here, such as special abilities
}