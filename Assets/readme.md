# Project Assets Structure

This document provides an overview of the folders within the `Assets` directory of our Unity project. Each folder has a specific role in the organization and management of our game's resources.

## Art

- **Description**: Contains all the graphical assets including sprites, textures, and models. Organized subfolders by type or game feature for better management.
- **Subfolders**: `Sprites`, `Textures`, `Models`, `Animations`

## Audio

- **Description**: Holds all audio files used in the game, including music tracks and sound effects (SFX).
- **Subfolders**: `Music`, `SFX`

## Data

- **Description**: Used for storing game data files, such as JSON/XML for configuration, levels, character stats, etc. This folder can also contain ScriptableObjects for easy data management within the Unity Editor.
- **Subfolders**: `Config`, `Levels`, `Characters`

## Prefabs

- **Description**: Contains all prefab files. Prefabs are pre-configured game objects that can be reused across the game scenes.
- **Subfolders**: `Characters`, `Items`, `UIComponents`

## Scenes

- **Description**: This folder houses all the scene files of the game. Scenes are organized by game sections, such as main menu, levels, or other significant game divisions.
- **Subfolders**: `MainMenu`, `Levels`, `BattleScenes`

## Scripts

- **Description**: Contains all C# scripts. The scripts are organized by their roles within the game, such as gameplay, UI, utilities, and data management.
- **Subfolders**: `Gameplay`, `UI`, `Utilities`, `Data`, `Managers`

---

## General Guidelines

- **Organization**: Keep the assets organized in their respective folders. Use subfolders where necessary to keep similar assets grouped together.
- **Naming Conventions**: Use clear and consistent naming conventions for files and folders to ensure they are easily identifiable and searchable.
- **Documentation**: Document any complex systems or workflows to ensure team members can understand and work with them efficiently.
- **Optimization**: Regularly review and optimize assets for performance, including reducing the size of large images and audio files without compromising quality.
