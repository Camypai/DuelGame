using Duel.ScriptableObjects;


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
            State.HealthPoints -= _damage;
            if (State.HealthPoints <= 0)
            {
                State.IsDead = true;
            }
        }
    }
}