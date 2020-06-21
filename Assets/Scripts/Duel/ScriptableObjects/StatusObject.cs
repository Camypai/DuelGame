using Duel.Enums;
using Duel.Helpers;
using UnityEngine;
using UnityEngine.Serialization;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "status", menuName = "Duel/ScriptableObjects/Status", order = 0)]
    public class StatusObject : ScriptableObject
    {
        public float      time;
        public float      interval;
        public StatusType statusType;
        
        [ShowInInspectorByStatus(StatusType.Damage)]
        public float      damage;
        
        [ShowInInspectorByStatus(StatusType.Defence)]
        public float      defencePoints;
    }
}