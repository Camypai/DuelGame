using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "{name}_item", menuName = "Duel/ScriptableObjects/Item", order = 0)]
    public class ItemObject : ScriptableObject
    {
        public GameObject item;
        public StatusObject status;
    }
}