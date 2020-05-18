using Duel.ScriptableObjects;
using Duel.Services;
using UnityEngine;


namespace Duel.Entities
{
    public class Character
    {
        private UsableServices _services;
        // private GameObject _character;
        // private float _damage;
        private Animator _animator;
        
        private static readonly int IsShoot = Animator.StringToHash("isShoot");
        private static readonly int IsWin = Animator.StringToHash("isWin");
        private static readonly int IsDefeat = Animator.StringToHash("isDefeat");
        private static readonly int HasHit = Animator.StringToHash("hasHit");
        
        public Character(CharacterObject characterObject, UsableServices services)
        {
            var character = Object.Instantiate(characterObject.character);
            // _damage = characterObject.damage;
            _animator = character.GetComponent<Animator>();

            _services = services;
        }

        public void Shoot()
        {
            _animator.SetTrigger(IsShoot);
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
            _animator.SetTrigger(IsDefeat);
        }
    }
}