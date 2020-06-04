using System.Collections.Generic;
using Duel.Entities;
using Duel.Entities.Statuses;
using Duel.Enums;
using Duel.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;


namespace Duel.Contexts
{
    public class GameContext : Context
    {
        private float _oppositeHealthPoints;

        public float OppositeHealthPoints
        {
            get => _oppositeHealthPoints;
            set
            {
                _oppositeHealthPoints = value;
                HealthPointsNotify?.Invoke(PlayerType.Opponent, _oppositeHealthPoints);
            }
        }

        public bool NeedThrow;
        public int? FaceValue;

        public State State;

        public List<Status>     Statuses    = new List<Status>();
        public List<GameObject> Characters  = new List<GameObject>();
        public List<Status>     GetStatuses = new List<Status>();
        public bool             TakeStatus  = false;
        public bool             GameIsEnd   = false;
        public List<Image>      Images      = new List<Image>();

        public delegate void HealthPointsHandler(PlayerType playerType, float value);

        public event HealthPointsHandler HealthPointsNotify;

        private static GameContext _gameContext;

        private GameContext()
        {
        }

        public static GameContext GetGameContext()
        {
            return _gameContext ?? (_gameContext = new GameContext());
        }
    }
}