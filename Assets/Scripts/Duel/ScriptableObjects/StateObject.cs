using UnityEngine;


namespace Duel.ScriptableObjects
{
    [CreateAssetMenu(fileName = "state", menuName = "Duel/ScriptableObjects/State", order = 0)]
    public class StateObject : ScriptableObject
    {
        [Header("Здоровье")]
        public float healthPoints = 100f;

        [Header("Состояние")] 
        public bool isDead = false;
    }
}