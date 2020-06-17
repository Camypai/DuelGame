using System.Collections.Generic;
using System.Linq;
using Duel.Contexts;
using Duel.Enums;
using Duel.Interfaces;
using Duel.Services;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using EventType = Duel.Enums.EventType;
using Player = Duel.Prototypes.Player;


namespace Duel.Systems
{
    public class TurnBaseSystem : System, IAwakeSystem, IStartSystem, IFixedUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;
        private          int         _turnCount;
        private          Player      _player1;
        private          Player      _player2;
        private          bool        _haveCalculated = false;

        #endregion


        #region ctor

        public TurnBaseSystem(Context context, UsableServices services) : base(context, services)
        {
            _turnCount = 1;
            _context   = _mainContext as GameContext;
        }

        #endregion


        #region Private methods

        private void BeginOfTurn()
        {
        }

        private void EndOfTurn()
        {
        }

        private void SendFirstTurn(int? value)
        {
            if (_turnCount == 1)
            {
                PhotonNetwork.RaiseEvent((byte) EventType.FirstTurn, value.Value,
                                         new RaiseEventOptions {Receivers = ReceiverGroup.MasterClient},
                                         SendOptions.SendReliable);
            }
        }

        private void ComputeFirstTurnType()
        {
            if (!_haveCalculated)
            {
                if (_player1.FaceValue.Equals(_player2.FaceValue))
                {
                    Roll();
                }
                else
                {
                    if (_player1.FaceValue > _player2.FaceValue)
                    {
                        _player1.TurnType = TurnType.Attack;
                        _player2.TurnType = TurnType.Defence;
                    }
                    else
                    {
                        _player2.TurnType = TurnType.Attack;
                        _player1.TurnType = TurnType.Defence;
                    }

                    _haveCalculated = true;

                    var players = JsonConvert.SerializeObject(_context.Players);

                    Debug.Log(players);
                    Debug.Log(_haveCalculated);

                    PhotonNetwork.RaiseEvent((byte) EventType.BeginOfTurn, players,
                                             new RaiseEventOptions {Receivers = ReceiverGroup.All},
                                             SendOptions.SendReliable);
                }
            }
        }

        private void Roll()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                _player1.FaceValue = null;
                _player2.FaceValue = null;
                PhotonNetwork.RaiseEvent((byte) EventType.Roll, null,
                                         new RaiseEventOptions {Receivers = ReceiverGroup.All},
                                         SendOptions.SendReliable);
            }
        }

        #endregion


        #region IStartSystem

        public void Start()
        {
            Roll();
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (var player in PhotonNetwork.CurrentRoom.Players)
                {
                    _context.Players.Add(new Player
                    {
                        Id = player.Value.ActorNumber
                    });
                }

                _player1 = _context.Players.First();
                _player2 = _context.Players.Last();
            }

            _context.EndOfTurnNotify   += EndOfTurn;
            _context.BeginOfTurnNotify += BeginOfTurn;
            _context.FaceValueNotify   += SendFirstTurn;
        }

        #endregion


        #region IFixedUpdateSystem

        public void FixedUpdate()
        {
            if (PhotonNetwork.IsMasterClient && _turnCount == 1 && _context.Players.All(q => q.FaceValue.HasValue))
            {
                ComputeFirstTurnType();
            }
        }

        #endregion
    }
}