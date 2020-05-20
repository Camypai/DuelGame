using Duel.Enums;
using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "status", menuName = "Duel/ScriptableObjects/Status", order = 0)]
    public class StatusObject : ScriptableObject
    {
        public float time;
        public float interval;
        public float damage;
        public StatusType statusType;
    }
}