using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


namespace Duel.Behaviour
{
    public class WaitingController : MonoBehaviourPunCallbacks
    {
        private bool _isLoaded = false;
        
        private void Update()
        {
            // Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient && !_isLoaded)
            {
                _isLoaded = true;
                PhotonNetwork.LoadLevel(2);
            } 
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log($"Player entered room: {newPlayer.NickName}");
        }
    }
}