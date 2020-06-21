using System;
using Duel.Entities;
using Duel.Enums;
using UnityEngine.Serialization;


namespace Duel.Prototypes
{
    [Serializable]
    public class StatusPrototype
    {
        public float      time;
        public float      interval;
        public StatusType statusType;
        public float      damage;
        public float defencePoints;
    }
}