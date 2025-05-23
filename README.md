# SyntheticSoil

**SyntheticSoil** is a Unity-based tool to procedurally generate realistic soil images from granulometry data. It reads particle size distributions (PSDs) from a text file and spawns 3D particle prefabs to match the specified sieve percentages (BNQ 2501-025).

---

## Features

- Reads a PSD line of 32 floats, of which the first 11 correspond to standard sieve sizes (mm):
0.080, 0.160, 0.315, 0.630, 1.250, 2.500, 5.00, 10.00, 14.00, 20.00, 31.50

- Procedurally arranges granular particles in a Unity scene.
- Adjustable total sample mass (`Weight`) via script.
- Lightweight: 50 GB of 3D FBX particle models are kept external to the repo.
  
### Particle Assets
All 3D particle prefabs (.fbx) live under: Particules/Stone_prefabs/

### Important:

Each prefab must have Tag set to "particule"

Each prefab must have Layer set to "Sphere"

If tags or layers are missing, select all prefabs in Unity’s Project window, and assign them at once via the Inspector.

### Usage
Open the Unity scene Assets/Scenes/Interface.unity.

In the Interface scene, run Play.

In the on-screen UI, click Import PSD File and select your .txt file:

Only the first 11 values are used for now.

The tool will generate a 3D soil sample matching the distribution.

### Adjusting Sample Mass
To change the total mass of particles spawned, edit:Assets/Scene/CsvReader.cs
public float Weight = 1000.0f;  // total sample mass in grams

### File Format:
0,000/0,000/0,500/0,400/0,100/0,000/0,000/0,000/0,000/.../0,000/ (32 values total) // remaining values

After execution, images are deposited in ImagesSynthetiques/ (top views) and ImagesSynthetiquesBottom/ (bottom views).

50 GB of 3D FBX particle models are kept external to the repo. (https://...)


---

## Getting Started

### Prerequisites

- Unity 2021.3 LTS or later
- Text file containing PSD lines (one line = one image/sample)
- Access to the Particle assets (see **Particle Assets** below)

### Clone the Repository

```bash
git clone https://github.com/<your-username>/SyntheticSoil.git
cd SyntheticSoil
