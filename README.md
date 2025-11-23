# Escape Training Facility

A first-person interaction-based Unity project featuring:
- Key pickup and door unlocking
- TV interaction with random screen materials & audio clips
- Freeze area for guided jump training
- Player respawn system when falling off the map
- World-space instruction UI and animated arrow guide
- Complete FPS controller (movement, look, jump, crouch, interactions)

This project is designed as a gameplay mechanics demo for learning and testing interaction systems in Unity.

---

## 🎮 Features

### ✔ FPS Movement System
- WASD movement  
- Mouse look  
- Space to jump  
- Shift to crouch  
- Interaction with `E`  
- Coded using `CharacterController`

### ✔ Interaction System
- Trigger-based interactions (no raycast)
- Dynamic UI that shows and hides based on distance
- Clean and modular scripts for:
  - TV switching (with random audio & material pairing)
  - Key pickup
  - Door opening/closing
  - Freeze zone behavior

### ✔ TV Interaction
- Two random materials for TV screen  
- Two matching audio clips  
- Every time TV is turned ON, a random pair is selected  
- 3D audio with looping enabled  

### ✔ Key & Door System
- Key is picked using `E`
- Door only opens when the key is collected  
- UI feedback for both states  

### ✔ Freeze Area (Jump Training Zone)
- Player movement & camera rotation freeze  
- Player auto-rotates to face a wall  
- World-space UI shows:
  - “Press Space to Jump”
  - Jump Counter  
- Up/down animated arrow on UI  
- Jump counter updates on each jump  

### ✔ Player Respawn
- Fall detector under map  
- When player falls, teleport back to respawn point  
- Safe and smooth respawn (CharacterController disabled & re-enabled)

---
