using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "dice_object", menuName = "Duel/ScriptableObjects/Dice", order = 0)]
    public class DiceObject : ScriptableObject
    {
        public GameObject dice;
        public float strength;
        public Vector3 activePosition;
        public Vector3 hidePosition;
        public Material otherDice;
    }
}