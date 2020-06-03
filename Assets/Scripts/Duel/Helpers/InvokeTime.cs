using System;


namespace Duel.Helpers
{
    public class InvokeTime : Invoke
    {
        #region Fields

        public double StartTime;
        public float Interval;
        public double Timer;
        public float Time;
        public Action Callback;

        #endregion


        #region ClassLifeCycles

        public InvokeTime(Action method, double startTime, float time, float interval, Action callback = null) : base(method)
        {
            StartTime = startTime;
            Interval = interval;
            Time = time;
            Callback = callback;
        }

        #endregion
    }
}