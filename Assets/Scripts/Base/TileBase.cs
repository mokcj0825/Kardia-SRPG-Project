using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    public bool isWalkable;
    public int movementCost;
    // Add more properties related to the terrain and its status
    public TerrainType terrainType; // Enum for different types of terrain
    public UnitBase occupant; // Reference to a unit occupying this tile, if any

    // Enum for easy management of terrain types. Add as many types as your game needs.
    public enum TerrainType
    {
        Plain,
        Forest,
        Mountain,
        Water,
        // etc.
    }

    void Start()
    {
        InitializeTile();
    }

    // Initializes tile properties, such as determining its terrain type and initial state
    protected virtual void InitializeTile()
    {
        // Initialization logic here
        // For example, setting terrainType based on location or predefined map settings
    }

    // Updates the tile's walkability based on its current state or occupant
    public void UpdateWalkability()
    {
        // For instance, if a unit occupies the tile, it becomes unwalkable
        isWalkable = occupant == null;
    }

    // Call this method to assign a unit to this tile
    public void SetOccupant(UnitBase unit)
    {
        occupant = unit;
        UpdateWalkability();
    }

    // Call this method to remove a unit from this tile
    public void RemoveOccupant()
    {
        occupant = null;
        UpdateWalkability();
    }

    // Optional: Implement methods that react to game events, like entering combat or triggering traps
    protected virtual void OnEnter(UnitBase unit)
    {
        // Define actions taken when a unit enters this tile, like ambushes or bonuses
    }

    protected virtual void OnExit(UnitBase unit)
    {
        // Define actions taken when a unit leaves this tile, such as removing buffs or deactivating traps
    }
}