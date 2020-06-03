using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "statuses", menuName = "Duel/ScriptableObjects/Statuses", order = 0)]
    public class StatusesObject : ScriptableObject
    {
        public StatusObject[] Statuses;
    }
}