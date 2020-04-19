# [Demo](https://smfils1.github.io/DOR/)

## Running Locally

```bash
git clone https://smfils1.github.io/DOR/ # or clone your own fork
```
Open project using UnityHub or Unity. The project is being developed in Unity 2019.3.1f1

# Game Design Document

## Summary

Defend or Run, the choice is yours. However, there is nothing better than staying alive. This 3D minimalized third-person PC game is a battle between you and your enemies that require smarts and skills. The ability to attack or avoid increasingly damaging attacks leads to a unique strategy experience.


## Story

The game takes place on a stage, as seen in Figure 1. There are three character types; player, enemy, and protectee. The protectee is who or what the player is protecting that is positioned behind the player. Since we can’t see who the player is defending, it is up to our imagination to come up with who or what it is. The player is paid an amount of money each time it protects the protectee but the player also has the option to save itself by abandoning the protectee. In doing so, the player can continue to live and earn money. The goal is to make as much money as possible, and possibly more than you ever made.


## Mechanics


### Scoring:

Scoring is based on two variables as shown in Figure 6. The first is money earned for defending. Defending in this game means colliding with the enemy. If the player collides into an enemy, the score increases by five. The second variable is time. The player is rewarded by how long it’s alive. Every 5 seconds the player lives, it earns 5 points. Also, the player is in a winning state if their score is a high score.


### Movement:

The player has both vertical & horizontal movement as shown in Figure 3. If the up, down, left, and right arrow keys are pressed the player moves forward, backward, left, and right respectively at a constant speed. If the space key is pressed the player moves upward to simulate a jump. For the enemy, there is only horizontal movement as seen in Figure 4. More specifically, the enemy can only move in the negative z-axis at an increasing speed until it has been deflected as a result of hitting a character.

There are two restrictions that a player's movement has. The first is the boundary it can move within. If a player falls off the stage, the player is killed and game over is triggered. Figure 2 shows the stage contained within a 3D rectangular boundary space. 

The second movement restriction is the player jump time. The longer the space key is pressed the higher the player can jump. However, there is a time limit to which a player can be in the air as a result of jumping. In Figure 3, if space is pressed, the start time is saved and the max time of jumping is calculated. The player will gain an upward velocity until time equal to the max time of startTime + timeLimit. During the time in the air, if the down arrow key is pressed, the player’s downward velocity increases. This creates a jumping mechanism that will allow the player to control how high it wants to jump and also how fast it wants to land.


### Randomization:

The stage is divided into two parts, the wall and the ground as seen in Figure 1. The wall is where enemies will spawn randomly. More specifically, the square area behind the wall is where the enemy spawn. By finding the max and min x & y values of the corners of the wall, the range of numbers in the x & y axis creates a square area for possible spawning locations. Figure 4 shows the 3D position of the wall & the 2D space where an enemy will randomly spawn.


### Progression:

As time progresses, the difficulty increases. The difficulty of the game is measured in three ways. The first two measurement changes based on time. When time passes, a time-based value is added to the speed of the enemy as shown in the math formula in Figure 5. The same concept is applied to how fast enemies spawn. However, we need to decrease the wait time for spawning enemies so spawning is faster over time. The formula for this is shown in Figure 5. 

The third measurement is the strength of the player and enemy. The strength of a character is calculated by its mass. The more one weighs the more power one has to push a character of the stage. Figure 6 compares the collisions between the player and enemy where the mass of the player changes. This game physics is used as attacks. If the player fails to defend the protectee, the mass of the player decreases by some units until it weighs about 1 unit. Also, the enemy gains some mass after a successful attack. This functionality gives enemies the ability to get stronger and players the ability to get weaker.

These measurements lead to different game modes shown in Figure 7 settings menu. Each mode uses a different initial speed & waitTime. As a result, one can jump into different progressions of the game. The default mode is easy, but can be changed in the settings menu.


## Dynamics

The combination of the above mechanism emerges survival and risk & reward dynamics. As time goes by and the player fails to defend the protectee, the strategy of the game slowly evolves from defending to dodging enemy attacks. As a result, the player needs to weigh the risks & rewards. The player can defend to earn money fast or dodge attacks to earn money by staying alive. Unique strategy emerges like protecting the protectee closer to the enemy to minimize the chances of fall off the stage. The game encourages players to stay focused from the start of the game to avoid future consequences.


## UI

From the menus to the game assets, minimalism is the focus. The characters are simple shapes. To signal danger, the enemy is red. The stage and background are some shade of black. For the menu, simple transitions are used as seen in Figure 7. The start scene is the main menu that has two buttons; play and settings. Play will transition the player to a default game mode. If a game mode hasn't been set up, the default mode will be Easy. Settings will transition the player to select different game modes. As one is playing the game, if the player is killed, the game ends with a game over menu that has two buttons; retry and main menu. Retry will restart the game at the same game mode and the main menu will redirect one to the starting menu.


## Figures


!#[drawing](https://i.imgur.com/r5KKB03.png)
![drawing](https://i.imgur.com/deRxgL8.png)
![drawing](https://i.imgur.com/3xgorMj.png)
![drawing](https://i.imgur.com/5p0XL4Z.png)


