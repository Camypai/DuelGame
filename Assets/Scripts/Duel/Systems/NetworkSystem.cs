using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using NotImplementedException = System.NotImplementedException;


namespace Duel.Systems
{
    public class NetworkSystem : System, IAwakeSystem, IConnectionSystem
    {
        #region Private data

        private new MenuContext _context;
        private readonly Text _log;

        #endregion


        #region ctor

        public NetworkSystem(MenuContext context, UsableServices services, Text log) : base(services)
        {
            _context = context;
            _log = log;
        }

        #endregion


        #region Public methods

        public void Awake()
        {
            PhotonNetwork.NickName = $"Player {Random.Range(1000, 9999)}";
            Log($"Player's name is {PhotonNetwork.NickName}");

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "0.0.1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public void Connect()
        {
            Log("Connected to master");
        }

        public void Play()
        {
            Join();
        }

        public void JoinedRoom()
        {
            Log("Joined room");
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            Log($@"Join room fail:
Code: {returnCode};
Message: {message}");
            Create();
        }

        #endregion


        #region Private methods

        private void Log(string message)
        {
            Debug.Log(message);
            _log.text += $@"
{message}";
        }

        private void Join()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        private void Create()
        {
            PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 2});
        }

        #endregion
    }
}