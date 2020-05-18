using Duel.ScriptableObjects;
using UnityEngine;


namespace Duel.Contexts
{
    public class GameContext
    {
        public DiceObject DiceObject;
        public Transform ActivePosition;
        public Transform HidePosition;
        public bool NeedThrow;
        public int? FaceValue;
    }
}