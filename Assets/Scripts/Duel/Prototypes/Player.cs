using System;
using Duel.Enums;


namespace Duel.Prototypes
{
    [Serializable]
    public class Player
    {
        public int Id;
        public int? FaceValue;
        public TurnType TurnType = TurnType.None;
    }
}