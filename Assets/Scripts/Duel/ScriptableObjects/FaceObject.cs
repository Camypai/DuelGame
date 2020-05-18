using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "face_object", menuName = "Duel/ScriptableObjects/Face", order = 1)]
    public class FaceObject : ScriptableObject
    {
        public Transform Transform;
        public int Value;
    }
}