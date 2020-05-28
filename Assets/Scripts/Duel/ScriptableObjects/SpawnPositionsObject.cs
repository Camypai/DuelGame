using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "spawn_positions", menuName = "Duel/ScriptableObjects/Spawn Positions", order = 0)]
    public class SpawnPositionsObject : ScriptableObject
    {
        public Vector3 masterPosition;
        public Vector3 otherPosition;
    }
}