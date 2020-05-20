using Duel.ScriptableObjects;
using Duel.Services;
using UnityEngine;


namespace Duel.Entities
{
    public class Character
    {
        private UsableServices _services;
        private State _state;
        
        private readonly Animator _animator;

        private static readonly int IsShoot = Animator.StringToHash("isShoot");
        private static readonly int IsWin = Animator.StringToHash("isWin");
        private static readonly int IsDefeat = Animator.StringToHash("isDefeat");
        private static readonly int HasHit = Animator.StringToHash("hasHit");
        private static readonly int BaseLayer = Animator.StringToHash("Base Layer");
        
        public Character(CharacterObject characterObject, UsableServices services)
        {
            var character = Object.Instantiate(characterObject.character);
            _animator = character.GetComponent<Animator>();

            _services = services;
            _state = new State(characterObject.stateObject);
        }

        public void Shoot(bool value)
        {
            var current = _animator.GetBool(IsShoot);

            if(!current.Equals(value))
            {
                _animator.SetBool(IsShoot, value);
            }
        }

        public void Victory()
        {
            _animator.SetTrigger(IsWin);
        }

        public void HasDamage()
        {
            _animator.SetTrigger(HasHit);
        }

        public void Defeat()
        {
            if(_state.IsDead)
            {
                _animator.SetTrigger(IsDefeat);
            }
        }
    }
}