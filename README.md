# PUN Player Scores

A list of player scores with Photon Unity Networking synchronization.

### Usage:
0. Download latest release and import in Unity project **PUN-Player-Score.unitypackage**.
1. Add **PlayerScoreController.cs** to some empty game object.
2. Add **UIPlayersScores.cs** to the UI element where you want and assign Text field on this component.
3. Increment player score by example `PlayerScoreController.IncrementMatchScore(PhotonNetwork.LocalPlayer, 1);`
The first parameter is for whom incrementing the score, the second is how much score we adding. The second parameter may be negative.
