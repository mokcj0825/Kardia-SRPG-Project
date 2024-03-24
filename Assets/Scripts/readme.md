# Scripts Folder Structure

This document describes the organization of the `Scripts` directory in our Unity project. The directory is structured to separate script files by their functionality, making it easier to manage and understand the codebase.

## Base

- **Description**: Contains base classes and interfaces that are extended or implemented by other scripts throughout the project. This includes abstract classes, utility classes, and fundamental interfaces.
- **Examples**: `GameControllerBase.cs`, `CharacterBase.cs`, `IInteractable.cs`

## Characters

- **Description**: Houses scripts related to characters in the game, including player characters (PCs) and non-player characters (NPCs). This encompasses behavior, stats, movement, and interaction scripts.
- **Subfolders**: `Player`, `Enemies`, `NPCs`
- **Examples**: `PlayerController.cs`, `EnemyAI.cs`, `NPCDialogue.cs`

## UI

- **Description**: Contains scripts that manage the user interface (UI) of the game, including menus, in-game HUDs, inventory screens, and other interactive UI elements.
- **Examples**: `MenuManager.cs`, `HUDController.cs`, `InventoryScreen.cs`

## Utilities

- **Description**: Holds utility scripts that provide common functionality across the project. These scripts often include helpers, extensions, and managers that are not specific to game mechanics.
- **Examples**: `Singleton<T>.cs`, `CameraFollow.cs`, `AudioManager.cs`

---

## General Guidelines

- **Modularity**: Aim to keep scripts as modular as possible. This makes them easier to reuse and maintain.
- **Naming Conventions**: Adopt clear and consistent naming conventions for scripts and functions to ensure readability and ease of navigation.
- **Documentation**: Document the purpose and usage of each script, especially for base classes and utilities that are used widely across the project.
- **Refactoring**: Regularly review and refactor scripts to improve performance, reduce complexity, and enhance readability.

