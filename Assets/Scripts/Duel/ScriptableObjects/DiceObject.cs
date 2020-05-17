using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "dice_object", menuName = "Duel/ScriptableObjects/Dice", order = 0)]
    public class DiceObject : ScriptableObject
    {
        [FormerlySerializedAs("Dice")] public GameObject dice;
        [FormerlySerializedAs("FirstFace")] public Transform firstFace;
        [FormerlySerializedAs("SecondFace")] public Transform secondFace;
        [FormerlySerializedAs("ThirdFace")] public Transform thirdFace;
        [FormerlySerializedAs("FourthFace")] public Transform fourthFace;
        [FormerlySerializedAs("FifthFace")] public Transform fifthFace;
        [FormerlySerializedAs("SixthFace")] public Transform sixthFace;
        [FormerlySerializedAs("ActivePosition")] public Transform activePosition;
        [FormerlySerializedAs("HidePosition")] public Transform hidePosition;
    }
}