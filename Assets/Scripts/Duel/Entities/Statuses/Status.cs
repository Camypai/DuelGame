using Duel.Enums;
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

        public Status(StatusObject statusObject)
        {
            Time = statusObject.time;
            Interval = statusObject.interval;
            StatusType = statusObject.statusType;
            _damage = statusObject.damage;
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