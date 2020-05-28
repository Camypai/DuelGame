using System;
using Duel.Contexts;
using Duel.Enums;
using Duel.Helpers;
using Duel.Services;
using UnityEngine;
using UnityEngine.UI;


namespace Duel.Systems
{
    public class MenuSystem
    {
        #region Private data

        private NetworkSystem _networkSystem;

        private MenuContext _context;

        #endregion


        #region ctor

        public MenuSystem(MenuContext context, UsableServices services, Text log)
        {
            _context = context;
            // _systemCollection.Add(new NetworkSystem(context, services, log));
            _networkSystem = new NetworkSystem(context, services, log);
        }

        #endregion


        #region Public methods

        public void Awake()
        {
            _networkSystem.Awake();
        }

        public void Connect()
        {
            _networkSystem.Connect();
        }

        public void JoinedRoom()
        {
            _networkSystem.JoinedRoom();
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            _networkSystem.OnJoinRandomFailed(returnCode, message);
        }

        public void Play()
        {
            _networkSystem.Play();
        }

        public void Select()
        {
            _context.CharacterObject.character = _context.SelectCharacter;
            
        }

        #endregion
    }
}