using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "cell_{numeration}", menuName = "Duel/ScriptableObjects/Cell", order = 0)]
    public class CellObject : ScriptableObject
    {
        public Vector3 Position;
        public Vector3 Rotation;
    }
}