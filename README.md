# Cikwick Course Game

Cikwick Course Game is a 3D Unity game project developed as a course completion project during SkinnyDev's Unity game development camp.

The main goal of the game is to collect all eggs while avoiding the chasing cat and surviving the hazards in the level. The project includes player movement, jumping, sliding, collectibles, boosters, health system, UI animations, sound effects, camera shake, and win/lose conditions.

## Gameplay

In the game, the player controls a small character in a 3D environment. The player must collect eggs around the map while avoiding the cat and dangerous obstacles.

The game includes:

- Egg collection system
- Cat chase mechanic
- Player health system
- Win and lose conditions
- Jumping and sliding movement
- Speed and jump boosters
- Rotten wheat slow effect
- Fire damage system
- Animated UI panels
- Background music and sound effects
- Camera shake feedback
- Main menu and game scene flow

## Controls

| Action | Key |
|---|---|
| Move | WASD / Arrow Keys |
| Jump | Space |
| Slide | Assigned slide key in Unity input settings |

## Technologies Used

- Unity 6
- C#
- Universal Render Pipeline
- TextMesh Pro
- DOTween
- Unity NavMesh
- Unity Timeline

## Project Structure

The project includes two main scenes:

- `MenuScene`
- `GameScene`

Main gameplay scripts are located under:

```txt
Assets/_GameAssets/scripts
```

Some important systems:

- `PlayerController.cs` — handles movement, jumping, sliding, and player states
- `CatController.cs` — controls cat patrol and chase behavior
- `GameManager.cs` — manages game state, egg collection, win and lose logic
- `HealthManager.cs` — manages player health and death
- `EggCollectible.cs` — handles egg collection
- `GoldWheatCollectible.cs` — speed booster
- `HolyWheatCollectible.cs` — jump booster
- `RottenWheatCollectible.cs` — negative slow effect
- `FireDamageable.cs` — hazard damage system
- `SettingsUI.cs` — pause/settings menu
- `WinLoseUI.cs` — win and lose popups

## How to Run

Clone this repository:

```bash
git clone https://github.com/derdevz/cikwick_courseGame.git
```

Open the project with Unity Hub.

Use Unity version:

```txt
Unity 6000.0.25f1
```

Open the scene:

```txt
Assets/_GameAssets/Scenes/MenuScene.unity
```

or

```txt
Assets/_GameAssets/Scenes/GameScene.unity
```

Press Play in the Unity Editor.

## Credits

This project was developed as part of SkinnyDev's Unity game development course.

Course assets were provided for project use by the course creator.  
The implementation, project setup, gameplay systems, and adjustments were completed by me as part of the learning process.

Course video:  
[SkinnyDev Unity Game Development Course](https://youtu.be/KZ5V9xIwwcE)

## Notes

This project was created for learning and portfolio purposes.  
It helped me practice Unity, C#, player controls, UI systems, collectibles, game states, and basic enemy AI behavior.

Notes

This project was created for learning and portfolio purposes.
It helped me practice Unity, C#, player controls, UI systems, collectibles, game states, and basic enemy AI behavior.
