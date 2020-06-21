using Duel.Enums;
using Duel.Prototypes;
using Duel.ScriptableObjects;


namespace Duel.Entities.Statuses
{
    public abstract class Status
    {
        #region Fields

        public float Time;
        public float Interval;
        public StatusType StatusType;
        protected State State;

        protected float _damage;

        #endregion


        #region ctor

        protected Status(StatusObject statusObject)
        {
            Time = statusObject.time;
            Interval = statusObject.interval;
            StatusType = statusObject.statusType;
            _damage = statusObject.damage;
        }

        protected Status(StatusPrototype statusPrototype)
        {
            Time       = statusPrototype.time;
            Interval   = statusPrototype.interval;
            StatusType = statusPrototype.statusType;
            _damage    = statusPrototype.damage;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Сброс параметров статуса
        /// </summary>
        public virtual void Reset()
        {
            State = null;
        }

        /// <summary>
        /// Внешний вид статуса
        /// </summary>
        protected virtual void Effect(){}

        public void SetState(State state)
        {
            State = state;
        }

        public abstract void Use();

        #endregion
    }
}