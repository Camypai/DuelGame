using Duel.ScriptableObjects;
using UnityEngine;


namespace Duel.Entities
{
    public class Dice
    {
        #region Private data

        private readonly GameObject _dice;
        private readonly Rigidbody _rigidbody;
        private Transform _firstFace;
        private Transform _secondFace;
        private Transform _thirdFace;
        private Transform _fourthFace;
        private Transform _fifthFace;
        private Transform _sixthFace;
        private Transform _activePosition;
        private Transform _hidePosition;

        #endregion


        #region ctor

        public Dice(DiceObject diceObject)
        {
            _dice = diceObject.dice;
            _secondFace = diceObject.secondFace;
            _thirdFace = diceObject.thirdFace;
            _fourthFace = diceObject.fourthFace;
            _fifthFace = diceObject.fifthFace;
            _sixthFace = diceObject.sixthFace;
            _firstFace = diceObject.firstFace;

            _activePosition = diceObject.activePosition;
            _hidePosition = diceObject.hidePosition;
            
            _rigidbody = _dice.GetComponent<Rigidbody>();
        }

        #endregion


        #region Public methods

        public void Throw()
        {
            GoToTheActivePosition();
            _rigidbody.AddForce(Vector3.forward);
        }

        public void BackToTheHidePosition()
        {
            _dice.transform.position = _hidePosition.position;
        }

        #endregion


        #region Private methods

        private void GoToTheActivePosition()
        {
            _dice.transform.position = _activePosition.position;
        }

        #endregion
    }
}