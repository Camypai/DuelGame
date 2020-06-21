using System;
using Duel.Enums;


namespace Duel.Helpers
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class ShowInInspectorByStatusAttribute : Attribute
    {
        public StatusType StatusType { get; set; }

        public ShowInInspectorByStatusAttribute(StatusType statusType)
        {
            StatusType = statusType;
        }
    }
}