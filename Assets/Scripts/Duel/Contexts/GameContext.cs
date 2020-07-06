using System.Collections.Generic;
using Duel.Entities;
using Duel.Entities.Statuses;
using Duel.Enums;
using Duel.Prototypes;
using UnityEngine;
using UnityEngine.UI;


namespace Duel.Contexts
{
    public class GameContext : Context
    {
        #region Private data

        private static GameContext _gameContext;
        private        float       _oppositeHealthPoints;
        private        bool        _endOfTurn;
        private        bool        _beginOfTurn;
        private        int?        _faceValue;
        private        int?        _oppositeFaceValue;

        #endregion


        #region Public data

        public float OppositeHealthPoints
        {
            get => _oppositeHealthPoints;
            set
            {
                _oppositeHealthPoints = value;
                HealthPointsNotify?.Invoke(PlayerType.Opponent, _oppositeHealthPoints);
            }
        }

        public bool EndOfTurn
        {
            get => _endOfTurn;
            set
            {
                _endOfTurn = value;
                if (_endOfTurn)
                {
                    EndOfTurnNotify?.Invoke();
                }
            }
        }

        public bool BeginOfTurn
        {
            get => _beginOfTurn;
            set
            {
                _beginOfTurn = value;
                if (_beginOfTurn)
                {
                    BeginOfTurnNotify?.Invoke();
                }
            }
        }

        public int? FaceValue
        {
            get => _faceValue;
            set
            {
                _faceValue = value;
                FaceValueNotify?.Invoke(_faceValue);
            }
        }

        public bool NeedThrow;

        // public int? OppositeFaceValue
        // {
        //     get => _oppositeFaceValue;
        //     set
        //     {
        //         _oppositeFaceValue = value;
        //         FaceValueNotify?.Invoke(_oppositeFaceValue);
        //     }
        // }

        public State State;

        public List<Status>     Statuses    = new List<Status>();
        public List<GameObject> Characters  = new List<GameObject>();
        public List<Status>     GetStatuses = new List<Status>();
        public bool             TakeStatus  = false;
        public bool             GameIsEnd   = false;
        public List<Image>      Images      = new List<Image>();
        public List<PlayerPrototype>     Players     = new List<PlayerPrototype>();
        public TurnType         TurnType;
        public bool             PlayTurn;
        public Camera           Camera;

        #endregion


        #region Delegates

        public delegate void HealthPointsHandler(PlayerType playerType, float value);

        public delegate void EndOfTurnHandler();

        public delegate void BeginOfTurnHandler();

        public delegate void FaceValueHandler(int? value);

        #endregion


        #region Events

        public event HealthPointsHandler HealthPointsNotify;
        public event EndOfTurnHandler    EndOfTurnNotify;
        public event BeginOfTurnHandler  BeginOfTurnNotify;
        public event FaceValueHandler    FaceValueNotify;

        #endregion


        #region ctor

        private GameContext()
        {
        }

        #endregion


        #region Public methods

        public static GameContext GetGameContext()
        {
            return _gameContext ?? (_gameContext = new GameContext());
        }

        #endregion
    }
}