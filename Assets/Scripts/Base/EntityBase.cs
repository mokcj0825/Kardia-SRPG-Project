using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviourBase
{
    public int baseHealth;
    public int currentHealth;
    public int baseAttack;
    public int baseDefense;
    public Vector2 gridPosition;


    // Initialize entity-specific properties. This could be overridden to setup entity-specific behaviors.
    protected override void Start()
    {
        base.Start(); // Calls the base Start method for any general initialization
        InitializeEntity();
    }

    // Method for entity initialization
    protected virtual void InitializeEntity()
    {
        // Set initial health, position, or other properties here
        currentHealth = baseHealth;
    }

    // Method for taking damage, could be overridden for damage effects or animations
    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Optional: Trigger some visual/audio effect when taking damage
        TriggerDamageEffect();

        if (currentHealth <= 0)
        {
            Die(); // Handle entity death in a separate method for better modularity
        }
    }

    // Method for moving the entity on the grid
    public virtual void Move(Vector2 newPosition)
    {
        // Optional: Trigger some movement animation or effect here
        TriggerMoveEffect();

        gridPosition = newPosition;
    }

    // Method to handle the entity's death
    protected virtual void Die()
    {
        // Optional: Play death animation or sound before destruction
        TriggerDeathEffect();

        Destroy(gameObject); // Destroy the entity object
    }

    // Method to trigger visual or audio effects when taking damage
    protected virtual void TriggerDamageEffect()
    {
        // Implement damage effects, such as flashing the sprite, playing a sound, etc.
    }

    // Method to trigger effects or animations upon moving
    protected virtual void TriggerMoveEffect()
    {
        // Implement move effects, such as particle trails, footsteps sounds, etc.
    }

    // Method to handle effects or animations upon death
    protected virtual void TriggerDeathEffect()
    {
        // Implement death effects, like animations, explosion effects, sounds, etc.
    }

    // Optional: Method for interacting with other entities or objects
    public virtual void Interact(EntityBase otherEntity)
    {
        // Define interactions, such as talking, attacking, or providing assistance
    }

}
