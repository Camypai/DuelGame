using System;
using System.Linq;
using Duel.Contexts;
using Duel.Entities.Statuses;
using Duel.Enums;
using Duel.Helpers;
using Duel.Services;
using Duel.Systems;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


namespace Duel.Behaviour
{
    public class GameController : MonoBehaviour, IOnEventCallback, IPunOwnershipCallbacks
    {
        private GameSystem _gameSystem;
        private UsableServices _services;
        private GameContext _context;

        private void Awake()
        {
            _context = new GameContext();
            _services = UsableServices.SharedInstance;
            _services.Initialize(_context);
            
            PhotonNetwork.AddCallbackTarget(this);
            
            _gameSystem = new GameSystem(_context, _services);
            
            _gameSystem.Awake();
        }

        private void Start()
        {
            _gameSystem.Start();
        }

        private void Update()
        {
            _gameSystem.Update();
        }

        private void FixedUpdate()
        {
            _services.Update();
            _services.Dispose();
            
            _gameSystem.FixedUpdate();
        }

        private void LateUpdate()
        {
            _gameSystem.LateUpdate();
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            targetView.TransferOwnership(requestingPlayer);
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
        }

        public void OnEvent(EventData photonEvent)
        {
            switch (photonEvent.Code)
            {
                case 1:
                    switch ((StatusType)photonEvent.CustomData)
                    {
                        case StatusType.None:
                            break;
                        case StatusType.Damage:
                            var statuses = _context.Statuses.Where(q => q.StatusType == StatusType.Damage);
                            _context.GetStatuses.AddRange(statuses);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case 2:
                    _context.GameEnd = true;
                    break;
            }
        }
    }
}