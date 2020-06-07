using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "world", menuName = "Duel/ScriptableObjects/World", order = 0)]
    public class WorldObject : ScriptableObject
    {
        public GameObject Camera;
    }
}