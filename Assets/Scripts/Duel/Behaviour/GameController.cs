using System;
using Duel.Contexts;
using Duel.Entities.Statuses;
using Duel.Enums;
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
            Debug.Log($"EVENT: {photonEvent}");
            switch (photonEvent.Code)
            {
                case 1:
                    switch ((StatusType)photonEvent.CustomData)
                    {
                        case StatusType.None:
                            break;
                        case StatusType.Damage:
                            Debug.Log("Damage!!!");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
            }
        }
    }
}