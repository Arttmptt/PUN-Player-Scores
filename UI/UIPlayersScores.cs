using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using PunPlayer = Photon.Realtime.Player;

public class UIPlayersScores : MonoBehaviour
{
    [SerializeField] Text _leaderboardResult;

    private void OnEnable()
    {
        PlayerScoreController.LeaderboardUpdate += DisplayPlayersList;
    }

    private void OnDisable()
    {
        PlayerScoreController.LeaderboardUpdate -= DisplayPlayersList;
    }

    private void DisplayPlayersList()
    {
        _leaderboardResult.text = null;
        PunPlayer[] players = PhotonNetwork.PlayerList
            .OrderByDescending(p => p.CustomProperties[NetworkKeys.RoomScore])
            .Take(4)
            .ToArray();

        foreach (PunPlayer player in players)
        {
            _leaderboardResult.text += $"{player.NickName} score: {player.CustomProperties[NetworkKeys.RoomScore]} \n";
        }
    }
}