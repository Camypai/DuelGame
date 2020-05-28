using System;
using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Duel.Systems
{
    public class WorldSystem : System, IAwakeSystem, IUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;
        private bool _isLoaded = false;

        #endregion


        #region ctor

        public WorldSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            var position = PhotonNetwork.IsMasterClient
                ? _context.PositionsObject.cameraMasterPosition
                : _context.PositionsObject.cameraOtherPosition;

            var rotate = PhotonNetwork.IsMasterClient
                ? _context.PositionsObject.cameraMasterRotate
                : _context.PositionsObject.cameraOtherRotate;
            var worldCamera = Object.Instantiate(_context.WorldObject.Camera, position,
                Quaternion.Euler(rotate));
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount < 2 && !_isLoaded)
            {
                _isLoaded = true;
                PhotonNetwork.LeaveRoom();
                PhotonNetwork.LoadLevel(0);
            }
        }

        #endregion
    }
}