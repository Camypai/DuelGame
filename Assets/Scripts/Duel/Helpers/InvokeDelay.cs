﻿using System;


namespace Duel.Helpers
{
    public class InvokeDelay : Invoke
    {
        #region Fields

        public float DelayTime;

        #endregion


        #region ClassLifeCycles

        public InvokeDelay(Action method, float delayTime) : base(method)
        {
            DelayTime = delayTime;
        }

        #endregion
    }
}