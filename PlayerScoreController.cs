using System;
using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using PunPlayer = Photon.Realtime.Player;

public class PlayerScoreController : MonoBehaviourPunCallbacks
{
    public static event Action LeaderboardUpdate;

    public static void IncrementMatchScore(PunPlayer player, int addScore)
    {
        if (player != null)
        {
            if (PhotonNetwork.InRoom && player.ActorNumber >= 0)
            {
                int oldValue = 0;
                if ((bool)player.CustomProperties?.ContainsKey(NetworkKeys.RoomScore))
                {
                    oldValue = (int)player.CustomProperties[NetworkKeys.RoomScore];
                }

                int newValue = oldValue + addScore;

                player.SetCustomProperties(new Hashtable() { { NetworkKeys.RoomScore, newValue } });
            }
            else Debug.LogWarning("[Player Score] players not in room");
        }
        else Debug.LogWarning("[Player Score] player parameter must not be null");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { NetworkKeys.RoomScore, 0 } });
    }

    public override void OnPlayerPropertiesUpdate(PunPlayer targetPlayer, Hashtable changedProps)
    {
        LeaderboardUpdate?.Invoke();
    }
}
