# Sharp Shooter

Sharp Shooter is a first-person shooter (FPS) game project built with Unity. The game features classic FPS mechanics such as player movement, shooting, enemy AI, turrets, scoring, and health management. This document provides an overview of the project's structure, main systems, and gameplay logic.

### Gameplay Video: https://youtu.be/B1gvPYveRt4
---

## Table of Contents

- [Project Structure](#project-structure)
- [Gameplay Overview](#gameplay-overview)
  - [Player](#player)
  - [Weapons](#weapons)
  - [Enemies](#enemies)
  - [Turrets](#turrets)
  - [Scoring System](#scoring-system)
  - [Health System](#health-system)
  - [UI & Menus](#ui--menus)
  - [Music & SFX](#music--sfx)
- [Scripts Overview](#scripts-overview)
- [How to Play](#how-to-play)

---

## Project Structure

The project is organized as follows:

- `Assets/Scripts/Player/` — Player, weapon, and health scripts
- `Assets/Scripts/Enemies/` — Enemy AI, health, and projectile scripts
- `Assets/Scripts/Misc/` — Game management and utility scripts
- `Assets/Imported Assets/StarterAssets/FirstPersonController/Scripts/` — First-person controller and input system
- `Assets/Prefabs/`, `Assets/Scenes/`, `Assets/Material/`, etc. — Game assets

---

## Gameplay Overview

### Player

- **Movement:** The player uses a first-person controller ([`StarterAssets.FirstPersonController`](Assets/Imported%20Assets/StarterAssets/FirstPersonController/Scripts/FirstPersonController.cs)) for smooth movement, jumping, and camera rotation.
- **Input:** Input is handled via [`StarterAssetsInputs`](Assets/Imported%20Assets/StarterAssets/InputSystem/StarterAssetsInputs.cs), supporting keyboard/mouse and gamepad.
- **Health:** Player health is managed by [`PlayerHealth`](Assets/Scripts/Player/PlayerHealth.cs), with shield UI and game over logic.

### Weapons

- **Weapon Switching:** The player can switch weapons using the [`ActiveWeapon`](Assets/Scripts/Player/ActiveWeapon.cs) script.
- **Shooting:** Shooting is handled by [`Weapon`](Assets/Scripts/Player/Weapon.cs), which uses raycasting to detect hits and applies damage to enemies.
- **Weapon Data:** Weapon properties (damage, fire rate, magazine size, etc.) are defined in [`WeaponSO`](Assets/Scripts/Player/WeaponSO.cs) ScriptableObjects.

### Enemies

- **AI:** Enemies such as robots use [`Robot`](Assets/Scripts/Enemies/Robot.cs) and Unity's NavMeshAgent to chase the player.
- **Health:** Enemy health is managed by [`EnemyHealth`](Assets/Scripts/Enemies/EnemyHealth.cs). When health reaches zero, the enemy is destroyed and the score is updated.
- **Projectiles:** Some enemies (e.g., turrets) shoot projectiles using [`Projectile`](Assets/Scripts/Enemies/Projectile.cs).

### Turrets

- **Behavior:** Turrets are stationary enemies that periodically fire projectiles at the player using the [`Turret`](Assets/Scripts/Enemies/Turret.cs) script.
- **Targeting:** Turrets rotate to face the player and instantiate projectiles aimed at the player's position.

### Scoring System

- **Score Tracking:** The score is managed by [`GameManager`](Assets/Scripts/Misc/GameManager.cs), which updates the UI and handles time bonuses.
- **Bonuses:** Players receive points for defeating enemies and can earn time-based bonuses for completing levels quickly.
- **Highscore:** The game tracks and saves the highscore using Unity's `PlayerPrefs`.

### Health System

- **Player:** The player's health is displayed via shield bars. Taking damage reduces health, and reaching zero triggers game over.
- **Enemies:** Enemies have their own health and play destruction effects when defeated.

### UI & Menus

- **Main Menu:** Managed by [`MainMenuManager`](Assets/Scripts/MainMenu/MainMenuManager.cs), allowing players to start or quit the game.
- **In-Game UI:** Displays ammo, health, score, enemies left, and win/game over screens.

### Music & SFX

- **Main Menu:** Managed by [`AudioPlayer`](Assets/Scripts/Misc/AudioPlayer.cs), plays a background music.
- **WeapoOs SFX:** Each weapon has it's own music clip for a shooting sfx which is played by the Audio Source in ActiveWeapon.
- **Explosion SFX:** Turrets and SpawnPortals have a Explosion SFX audio clip which is played when they are destroyed.
---

## Scripts Overview

- **Player Movement:** [`FirstPersonController`](Assets/Imported%20Assets/StarterAssets/FirstPersonController/Scripts/FirstPersonController.cs)
- **Input Handling:** [`StarterAssetsInputs`](Assets/Imported%20Assets/StarterAssets/InputSystem/StarterAssetsInputs.cs)
- **Weapon Logic:** [`Weapon`](Assets/Scripts/Player/Weapon.cs), [`ActiveWeapon`](Assets/Scripts/Player/ActiveWeapon.cs), [`WeaponSO`](Assets/Scripts/Player/WeaponSO.cs)
- **Enemy AI:** [`Robot`](Assets/Scripts/Enemies/Robot.cs), [`Turret`](Assets/Scripts/Enemies/Turret.cs)
- **Projectiles:** [`Projectile`](Assets/Scripts/Enemies/Projectile.cs)
- **Health:** [`PlayerHealth`](Assets/Scripts/Player/PlayerHealth.cs), [`EnemyHealth`](Assets/Scripts/Enemies/EnemyHealth.cs)
- **Background Music:** [`AudioPlayer`](Assets/Scripts/Misc/AudioPlayer.cs)
- **Game Management:** [`GameManager`](Assets/Scripts/Misc/GameManager.cs)
- **Physics Push:** [`BasicRigidBodyPush`](Assets/Imported%20Assets/StarterAssets/FirstPersonController/Scripts/BasicRigidBodyPush.cs) allows the player to push rigidbodies.

---

## How to Play

1. **Start the Game:** Launch from the main menu.
2. **Move:** Use WASD or left stick to move, mouse or right stick to look.
3. **Shoot:** Left mouse button or right trigger to shoot.
4. **Switch Weapons:** (If implemented) Use the assigned key/button.
5. **Defeat Enemies:** Shoot enemies and avoid their attacks.
6. **Survive:** Manage your health and defeat all enemies to win the level.
7. **Progress:** Advance to the next level or restart from the menu.

---
