using Duel.Enums;
using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "character", menuName = "Duel/ScriptableObjects/Character", order = 0)]
    public class CharacterObject : ScriptableObject
    {
        public GameObject character;
        public StateObject stateObject;
        public CharacterType characterType;
    }
}