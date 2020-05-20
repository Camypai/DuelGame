using System;
using System.Collections.Generic;
using System.Linq;
using Duel.ScriptableObjects;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Duel.Entities
{
    public class Dice
    {
        #region Private data

        private readonly GameObject _dice;
        private readonly Rigidbody _rigidbody;
        private readonly List<Models.Face> _faces = new List<Models.Face>();

        private readonly float _strange;
        private readonly Transform _activePosition;
        private readonly Transform _hidePosition;

        private bool _isThrew = false;

        #endregion


        #region ctor

        public Dice(DiceObject diceObject, Transform activePosition, Transform hidePosition)
        {
            _dice = Object.Instantiate(diceObject.dice);
            // BackToTheHidePosition();

            _faces.AddRange(_dice.GetComponentsInChildren<Models.Face>());


            _activePosition = activePosition;
            _hidePosition = hidePosition;

            _strange = diceObject.strange;

            _rigidbody = _dice.GetComponent<Rigidbody>();
        }

        #endregion


        #region Public methods

        public int? Throw()
        {
            // Debug.Log(_rigidbody.velocity.sqrMagnitude);
            var result = (int?) null;
            if (!_isThrew)
            {
                _isThrew = true;
                GoToTheActivePosition();

                _rigidbody.AddForce(Vector3.forward * _strange);
                _rigidbody.AddTorque(Vector3.one * _strange);
            }
            else if (_isThrew && Math.Abs(_rigidbody.velocity.sqrMagnitude) < 0.01f && Math.Abs(_rigidbody.angularVelocity.sqrMagnitude) < 0.01f)
            {
                _isThrew = false;

                result = GetTopFace();
            }

            return result;
        }

        public void BackToTheHidePosition()
        {
            _dice.SetActive(false);
            _dice.transform.position = _hidePosition.position;
            _rigidbody.isKinematic = true;
        }

        #endregion


        #region Private methods

        private void GoToTheActivePosition()
        {
            var position = _activePosition.position;
            _dice.transform.rotation = Random.rotation;
            _rigidbody.isKinematic = false;
            _dice.transform.position = position;
            _dice.SetActive(true);
        }

        private int? GetTopFace()
        {
            // Debug.Log(string.Join("\n",_faces.Select(q => q.transform.TransformPoint(Vector3.zero).y)));
            var max = _faces.Max(q => q.transform.TransformPoint(Vector3.zero).y);
            int? result = _faces.First(q => Math.Abs(q.transform.TransformPoint(Vector3.zero).y - max) < 0.02f).Value;

            return result;
        }

        #endregion
    }
}