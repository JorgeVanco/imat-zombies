# 🧟‍♂️ **iMAT Zombies**  
*Survive waves of zombies and showcase your strategic and survival skills!*  

---

## **📋 Table of Contents**
1. [🧐 Overview](#-overview)  
2. [🔥 Features](#-features)  
3. [🔧 Implementation Details](#-implementation-details)  
4. [🎮 How to Play](#-how-to-play)  
5. [🏗️ Development Details](#-development-details)  
   - [📐 Architecture](#-architecture)  
   - [📦 Design Patterns](#-design-patterns)  
6. [🚀 Future Improvements](#-future-improvements)  

---

## **🧐 Overview**

**iMAT Zombies** is a **survival shooter game** set in a post-apocalyptic world overrun by zombies.  
The player must defeat waves of enemies, manage resources, and strategically use available tools to survive as long as possible.  

🔑 **Key Highlights**:  
- Fast-paced action and strategic challenges.  
- Increasing difficulty with each round.  
- Implementation of **OOP principles** and **design patterns**.  

This project is the final assignment for the course **Programming Paradigms and Techniques** at **Universidad Pontificia Comillas (ICAI)**.  

---

## **Gameplay Video**

![Gameplay Video](video_ImatZombies.mp4)

---

## **🔥 Features**

- 🧟 **Zombie Waves**: Each round introduces more zombies and increases difficulty.  
- 🔫 **Weapon System**:  
  - Start with a knife.  
  - Upgrade to firearms and grenades through a chest.  
- 🎁 **Buying Chest**: Use points to buy weapons, ammo, and grenades.  
- ♻️ **Round Progression**:  
  - Recover health at the end of each round.  
  - More resources and rewards as you progress.  
- 🌟 **Zombie Types**:  
  - Fast, normal, and slow zombies, each with unique behaviors.  
- 🌍 **Dynamic Spawn Points**:  
  - Random spawning of zombies and ammunition across the map.  

---

## **🔧 Implementation Details**

### **🎯 Core Mechanics**
- **Survival Objective**: Survive as many waves as possible by defeating zombies and avoiding damage.  
- **Resource Management**: Earn points, collect ammo, and purchase weapons.  
- **Round System**: Each round increases in difficulty but also provides better rewards.  

### **🔍 Technical Highlights**
- **Player Interactions**:  
  - Use the chest to buy weapons or grenades.  
  - Collect ammo by walking over it.  
- **Zombie AI**:  
  - Zombies use pathfinding to pursue the player.  
- **Weapon System**:  
  - **Knife**: Melee attacks for close-range combat.  
  - **Firearms**: Guns with shooting and reloading mechanics.  
  - **Grenades**: Area explosions after a timer, causing damage to enemies and the player.  

---

## **🎮 How to Play**

### **Controls**
- **Movement**: Use `W`, `A`, `S`, `D`.  
- **Jump**: Press `Space`.  
- **Attack**: Left-click to use the equipped weapon.  
- **Interact with Chest**: Press `E` near the chest to open the buying menu.  
- **Switch Weapons**: Press `C` to toggle between weapons.  
- **Reload**: Press `R` or reload automatically when attempting to fire with no ammo.  
- **Collect Ammo**: Walk over ammo pickups on the ground.  

---

## **🏗️ Development Details**

### **📐 Architecture**
The project is structured into three core layers:

#### **1. Manager Layer**
Handles game systems, including:
- **GameManager**: Central control for gameplay and round progression.  
- **DataManager**: Manages persistent data (e.g., high scores).  
- **RoundManager**: Controls round logic and difficulty scaling.  
- **MenuManager**: Manages UI interactions and menus.  

#### **2. Scene Layer**
Includes game-specific components:  
- **Inventory**: Manages player items, weapons, and ammo.  
- **BuyingChest**: Handles purchasing weapons.  
- **Spawners**: Dynamically spawns zombies and ammo across the map.  

#### **3. Agent Layer**
Handles in-game entities:  
- **Character**: Represents the player, including health, inventory, and interactions.  
- **Zombies**: AI-driven enemies (Fast, Normal, Slow), created using the **Factory Design Pattern** for modularity and efficiency.  

---

### **📦 Design Patterns**
- **Singleton**: Used for managers (e.g., GameManager, BulletPool) to ensure centralized access and prevent duplication.  
- **Factory**: Dynamically creates different types of zombies.  
- **Observer**: Updates UI and other systems in response to gameplay events (e.g., round progression, zombie deaths).  
- **Object Pooling**: Manages bullets to improve performance and avoid excessive instantiation.  

---

## **🚀 Future Improvements**

1. **Enhanced Zombie AI**: Add behaviors like obstacle avoidance.  
2. **Expanded Arsenal**: Introduce more weapon types (e.g., shotguns, rifles).  
3. **Player Abilities**: Add special abilities like temporary speed boosts or shields.  
4. **Multiplayer Mode**: Allow cooperative gameplay for multiple players.

---

This project was developed as a final assignment for **Programming Paradigms and Techniques** at **Universidad Pontificia Comillas (ICAI)**. The development process involved learning Unity, implementing design patterns, and tackling challenges such as physics-based issues and UI interactions.  

### **Collaborators**
- [LydiaRuizMartinez](https://github.com/LydiaRuizMartinez)  
- [JorgeVanco](https://github.com/JorgeVanco)