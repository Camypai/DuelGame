using Duel.ScriptableObjects;
using UnityEngine;


namespace Duel.Entities.Statuses
{
    public class StatusDamage : Status
    {
        public StatusDamage(StatusObject statusObject) : base(statusObject)
        {
        }

        public override void Use()
        {
            Damage();
        }

        private void Damage()
        {
            Debug.Log(State.HealthPoints);
            State.HealthPoints -= _damage;
            if (State.HealthPoints <= 0)
            {
                State.IsDead = true;
            }
        }
    }
}