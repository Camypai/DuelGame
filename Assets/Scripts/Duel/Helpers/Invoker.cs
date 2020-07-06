using System;
using Duel.Entities.Statuses;
using Duel.Enums;
using Duel.Prototypes;
using Duel.ScriptableObjects;


namespace Duel.Helpers
{
    public class Invoker
    {
        public static Status CreateStatus(StatusObject statusObject)
        {
            Status result = null;

            switch (statusObject.statusType)
            {
                case StatusType.None:
                    break;
                case StatusType.Damage:
                    result = new StatusDamage(statusObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }
        
        public static Status CreateStatus(StatusPrototype statusPrototype)
        {
            Status result = null;

            switch (statusPrototype.statusType)
            {
                case StatusType.None:
                    break;
                case StatusType.Damage:
                    result = new StatusDamage(statusPrototype);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }
    }
}