# Base Class Documentation

This directory contains the base classes used across the SRPG/Warchess game development project. Each base class serves as a foundation for deriving more specific behaviors and functionalities required for the game. The classes are designed to ensure code reusability, scalability, and organization.

## Overview

Here is a brief overview of each base class and its intended purpose within the project:

### ControllerBase

- **Purpose**: Serves as the base for controllers managing game logic and flow.
- **Key Responsibilities**: Handling player inputs, managing game states, coordinating between different entities.

### EntityBase

- **Purpose**: Acts as the base for all entities in the game, such as characters and interactive objects.
- **Key Responsibilities**: Defining common attributes like health, managing basic behaviors such as taking damage or destruction.

### FactionControllerBase

- **Purpose**: Manages factions or teams within the game, including players and AI.
- **Key Responsibilities**: Managing turn orders, handling faction-specific logic and actions.

### GameManagerBase

- **Purpose**: Oversees the overall game state, including game phases and win/loss conditions.
- **Key Responsibilities**: Controlling state transitions, initializing the game, determining end conditions.

### InventoryBase

- **Purpose**: Manages the inventory for units or players, handling items and equipment.
- **Key Responsibilities**: Item management, including adding, removing, and using items.

### ItemBase

- **Purpose**: Serves as the foundational class for all items within the game, including equipment, consumables, and any other item types that may be interacted with or used by entities in the game.
- **Key Responsibilities**: Defines common properties and methods shared by all items, such as item IDs, names, descriptions, and the action to be taken when an item is used. This base class ensures that all items adhere to a consistent structure, facilitating inventory management, item usage, and interactions within the game world.
- **Notable Methods and Properties**:
    - `Use()`: A method that defines the action taken when an item is used. This might apply an effect, modify an entity's state, or trigger a game event, depending on the item's purpose.
    - `id`: A unique identifier for each item type, useful for inventory management, saving/loading game states, and referencing specific items.
    - `name`: The human-readable name of the item.
    - `description`: A brief description of the item, including its effects or uses within the game.

This class provides a unified framework for creating and managing items, allowing for easy expansion and customization of the game's item system. Derived classes can override the `Use()` method to implement specific behaviors, ensuring that each item type has a unique impact on the game.


### MapControllerBase

- **Purpose**: Manages the grid-based map and its functionalities.
- **Key Responsibilities**: Tile management, pathfinding, map-related events handling.

### MonoBehaviourBase

- **Purpose**: Serves as a base class for all MonoBehaviours, providing common utilities and functionality.
- **Key Responsibilities**: Facilitating initialization checks, common routines, and utility methods.

### TileBase

- **Purpose**: Represents the basic unit of the map's grid, holding terrain and occupancy information.
- **Key Responsibilities**: Storing data about the terrain, movement cost, and occupation status.

### UIControllerBase

- **Purpose**: Manages the game's user interface, including menus and game status displays.
- **Key Responsibilities**: UI management for displaying game data, interactive elements, and dialogs.

### UnitBase

- **Purpose**: A specialized EntityBase for units or characters capable of actions like moving or attacking.
- **Key Responsibilities**: Handling movement, action points, and unit-specific behaviors.

## Contribution Guidelines

When contributing to the project, please adhere to the following guidelines:

- **Code Style**: Maintain consistency with the existing project code style.
- **Documentation**: Clearly document any additions or changes to the base classes.
- **Testing**: Ensure your changes are thoroughly tested and do not introduce bugs.

## Further Development

These base classes are designed to be extensible. Developers are encouraged to derive more specific classes from these bases to meet the evolving needs of the game.

For any questions or suggestions regarding the base class architecture, please contact the project lead.
