using Duel.Constants;
using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


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


        #region IAwakeSystem

        public void Awake()
        {
            PhotonNetwork.NickName = $"Player {Random.Range(1000, 9999)}";
            Log($"Player's name is {PhotonNetwork.NickName}");

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = Constant.Version;
            PhotonNetwork.ConnectUsingSettings();
        }

        #endregion


        #region IConnectionSystem

        public void Connect()
        {
            Log("Connected to master");
            Log(PhotonNetwork.NickName);
        }

        #endregion


        #region Public methods

        public void Play()
        {
            Join();
        }

        public void JoinedRoom()
        {
            Log("Joined room");

            PhotonNetwork.LoadLevel(1);
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
            // Debug.Log(message);
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