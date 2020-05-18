using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "dice_object", menuName = "Duel/ScriptableObjects/Dice", order = 0)]
    public class DiceObject : ScriptableObject
    {
        [FormerlySerializedAs("Dice")] public GameObject dice;
        public float strange;
        [FormerlySerializedAs("FirstFace")] public FaceObject firstFace;
        [FormerlySerializedAs("SecondFace")] public FaceObject secondFace;
        [FormerlySerializedAs("ThirdFace")] public FaceObject thirdFace;
        [FormerlySerializedAs("FourthFace")] public FaceObject fourthFace;
        [FormerlySerializedAs("FifthFace")] public FaceObject fifthFace;
        [FormerlySerializedAs("SixthFace")] public FaceObject sixthFace;
        [FormerlySerializedAs("ActivePosition")] public Transform activePosition;
        [FormerlySerializedAs("HidePosition")] public Transform hidePosition;
    }
}