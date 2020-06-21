using System;
using System.Collections.Generic;
using System.Linq;
using Duel.Contexts;
using Duel.Enums;
using Duel.Helpers;
using Duel.Models;
using Duel.Prototypes;
using Duel.Services;
using Duel.Systems;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using EventType = Duel.Enums.EventType;


namespace Duel.Behaviour
{
    public class GameController : MonoBehaviour, IOnEventCallback, IPunOwnershipCallbacks
    {
        [SerializeField]
        private GameObject canvas;

        private GameSystem     _gameSystem;
        private UsableServices _services;
        private GameContext    _context;

        private void Awake()
        {
            _context  = GameContext.GetGameContext();
            _services = UsableServices.SharedInstance;
            _services.Initialize(_context);

            _context.Images.AddRange(canvas.GetComponentsInChildren<Image>()
                                           .Where(q => q.GetComponent<HealthBar>() != null));
            _context.Camera = Camera.main;

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
            switch ((EventType) photonEvent.Code)
            {
                case EventType.None:
                    break;
                case EventType.Status:
                    var statusesPrototype =
                        JsonConvert.DeserializeObject<List<StatusPrototype>>(photonEvent.CustomData.ToString());
                    _context.GetStatuses.AddRange(statusesPrototype.Select(Invoker.CreateStatus));

                    break;
                case EventType.GameIsEnd:
                    _context.GameIsEnd = true;
                    break;
                case EventType.RefreshEnemyHealthPoint:
                    _context.OppositeHealthPoints = (float) photonEvent.CustomData;
                    break;
                case EventType.FirstTurn:
                    if (PhotonNetwork.IsMasterClient)
                    {
                        var player = _context.Players.First(q => q.id == photonEvent.Sender);
                        player.faceValue = (int) photonEvent.CustomData;
                    }

                    break;
                case EventType.BeginOfTurn:
                    Debug.Log($"Begin of turn: {photonEvent.CustomData}");
                    var players =
                        JsonConvert.DeserializeObject<List<Prototypes.PlayerPrototype>>(
                            photonEvent.CustomData.ToString());

                    _context.Players = players;
                    _context.TurnType = _context.Players
                                                .First(q => q.id == PhotonNetwork.LocalPlayer.ActorNumber)
                                                .turnType;
                    break;
                case EventType.EndOfTurn:
                    break;
                case EventType.ContinueTurn:
                    break;
                case EventType.PlayTurn:
                    break;
                case EventType.Roll:
                    _context.NeedThrow = true;
                    break;
                default:
                    break;
            }
        }
    }
}