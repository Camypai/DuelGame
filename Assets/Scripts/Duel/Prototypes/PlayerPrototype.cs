using System;
using Duel.Enums;
using UnityEngine.Serialization;


namespace Duel.Prototypes
{
    [Serializable]
    public class PlayerPrototype
    {
        public int id;
        public int? faceValue;
        public TurnType turnType = TurnType.None;
    }
}