using Duel.Prototypes;
using Duel.ScriptableObjects;


namespace Duel.Entities.Statuses
{
    public class StatusDefence : Status
    {
        private float _defencePoints;
        
        public StatusDefence(StatusObject statusObject) : base(statusObject)
        {
            _defencePoints = statusObject.defencePoints;
        }

        public StatusDefence(StatusPrototype statusPrototype) : base(statusPrototype)
        {
            _defencePoints = statusPrototype.defencePoints;
        }

        public override void Use()
        {
            Defence();
        }

        private void Defence()
        {
            
        }
    }
}