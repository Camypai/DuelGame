using System.Collections.Generic;
using Duel.Entities;
using Duel.Entities.Statuses;
using Duel.ScriptableObjects;
using UnityEngine;


namespace Duel.Contexts
{
    public class GameContext : Context
    {
        // public DiceObject DiceObject;
        public bool NeedThrow;
        public int? FaceValue;
        public List<GameObject> Characters = new List<GameObject>();
        public List<GameObject> Dices = new List<GameObject>();
        public Status TakeStatus;
        public List<Status> GetStatuses = new List<Status>();

        // public CharacterObject CharacterObject;
        // public WeaponObject WeaponObject;
    }
}