# Garage
 
## Overview

**Garage Item Relocation** is a simple task-based game where the player needs to move objects from shelves into a pickup truck. The game focuses on resource management and interaction mechanics. It includes systems for item interactions, task tracking, and a user interface for tracking progress.

## Features

- **Item Interaction**: Players can pick up and drop items using the `PlayerItemHandler`. When a player looks at an item, the crosshair expands to indicate an interactive object.
- **Task System**: The `TaskManager` tracks progress as items are moved from shelves to the pickup area, notifying the player when the task is completed.
- **Dynamic UI**: The `TaskUIManager` updates the UI in real time to show task progress, including a progress bar for tasks and notifications upon task completion.
- **Crosshair System**: The crosshair expands when targeting interactive items and shrinks when not focused on any objects.
- **Basic Movement**: The player can move around using a `CharacterController`, jump, and interact with objects.