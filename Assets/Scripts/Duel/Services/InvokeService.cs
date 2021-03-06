﻿using System;
using System.Collections.Generic;
using Duel.Contexts;
using Duel.Helpers;
using Duel.Interfaces;
using Photon.Pun;
using UnityEngine;


namespace Duel.Services
{
    public class InvokeService : IInvokable
    {
        #region PrivateData

        private Context _context;

        private List<InvokeDelay> _invokeMethods = new List<InvokeDelay>();
        private List<InvokeTime> _invokeRepeatingMethods = new List<InvokeTime>();
        private List<InvokeDelay> _idInvokeMethodsForRemove = new List<InvokeDelay>();
        private List<InvokeTime> _idInvokeRepeatingMethodsForRemove = new List<InvokeTime>();

        private float _bias = 0.2f; // погрешность между 0 и жтим числом для сравнения с модулем

        #endregion


        #region ClassLifeCycles

        public InvokeService(Context context)
        {
            _context = context;
        }

        #endregion


        #region Methods

        public void Update()
        {
            foreach (var invokeDelay in _invokeMethods)
            {
                if (Math.Abs(Time.time - invokeDelay.DelayTime) <= _bias)
                {
                    invokeDelay.Method();
                    _idInvokeMethodsForRemove.Add(invokeDelay);
                }
            }

            foreach (var invokeTime in _invokeRepeatingMethods)
            {
                if(Math.Abs(invokeTime.Time) < 0.01f)
                {
                    invokeTime.Method();
                    _idInvokeRepeatingMethodsForRemove.Add(invokeTime);
                }
                else if (Time.time - invokeTime.StartTime <= invokeTime.Time)
                {
                    if (Math.Abs(Time.time - invokeTime.Timer) <= _bias)
                    {
                        invokeTime.Timer = Time.time + invokeTime.Interval;
                        invokeTime.Method();
                    }
                }
                else
                {
                    _idInvokeRepeatingMethodsForRemove.Add(invokeTime);
                }
            }
        }

        public void Dispose()
        {
            foreach (var invokeDelay in _idInvokeMethodsForRemove)
            {
                _invokeMethods.Remove(invokeDelay);
            }

            foreach (var invokeTime in _idInvokeRepeatingMethodsForRemove)
            {
                Debug.Log(_idInvokeRepeatingMethodsForRemove.Count);
                invokeTime.Callback?.Invoke();
                _invokeRepeatingMethods.Remove(invokeTime);
            }

            _idInvokeMethodsForRemove.Clear();
            _idInvokeRepeatingMethodsForRemove.Clear();
        }

        #endregion


        #region IInvokable

        /// <summary>
        /// Запуск метода через заданное количество времени
        /// </summary>
        /// <param name="method">Метод, который нужно запустить</param>
        /// <param name="delayTime">Заданное количество времени в секундах</param>
        public void Invoke(Action method, float delayTime)
        {
            var time = Time.time + delayTime + _bias; // конвертируем обычную задержку в нужную с помощью тайм и погрешностью
            _invokeMethods.Add(new InvokeDelay(method, time));
        }

        /// <summary>
        /// Выполнение метода в течение промежутка времени
        /// </summary>
        /// <param name="method">Метод, который нужно выполнять</param>
        /// <param name="time">Время выполнения метода</param>
        public void InvokeRepeating(Action method, float time, float interval, Action callback = null)
        {
            var invokeTime = new InvokeTime(method, PhotonNetwork.Time, time, interval, callback);
            invokeTime.Interval += _bias; // прибавляем погрешность чтобы не халтурить
            invokeTime.Timer = PhotonNetwork.Time; // чтобы тайм вычитался на тайм в первый тик и сработал моментально

            _invokeRepeatingMethods.Add(invokeTime);
        }

        #endregion
    }
}