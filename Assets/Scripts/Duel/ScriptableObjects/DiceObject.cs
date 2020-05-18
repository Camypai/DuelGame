using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "dice_object", menuName = "Duel/ScriptableObjects/Dice", order = 0)]
    public class DiceObject : ScriptableObject
    {
        [FormerlySerializedAs("Dice")] public GameObject dice;
        public float strange;
        [FormerlySerializedAs("ActivePosition")] public Transform activePosition;
        [FormerlySerializedAs("HidePosition")] public Transform hidePosition;
    }
}