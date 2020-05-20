using Duel.ScriptableObjects;


namespace Duel.Entities
{
    public class State
    {
        public float HealthPoints;
        public bool IsDead;

        public State()
        {
            
        }
        
        public State(StateObject stateObject)
        {
            HealthPoints = stateObject.healthPoints;
            IsDead = stateObject.isDead;
        }
    }
}