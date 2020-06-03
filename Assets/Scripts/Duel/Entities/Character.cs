using System.Collections.Generic;
using Duel.Constants;
using Duel.ScriptableObjects;
using Duel.Services;
using Photon.Pun;
using UnityEngine;


namespace Duel.Entities
{
    public class Character
    {
        private GameObject _character;
        private UsableServices _services;
        private State _state;
        private PhotonView _photonView;
        
        private readonly Animator _animator;

        private static readonly int IsShoot = Animator.StringToHash("isShoot");
        private static readonly int IsWin = Animator.StringToHash("isWin");
        private static readonly int IsDefeat = Animator.StringToHash("isDefeat");
        private static readonly int HasHit = Animator.StringToHash("hasHit");
        private static readonly int BaseLayer = Animator.StringToHash("Base Layer");
        
        public Character(CharacterObject characterObject, PositionsObject spawnPositionsObject, UsableServices services, List<GameObject> characters)
        {
            var position = PhotonNetwork.IsMasterClient
                ? spawnPositionsObject.spawnMasterPosition
                : spawnPositionsObject.spawnOtherPosition;
            var rotate = PhotonNetwork.IsMasterClient ? Vector3.forward : Vector3.back;
            _character = PhotonNetwork.Instantiate($"{Constant.NetworkPrefabsPath}{characterObject.character.name}", position, Quaternion.LookRotation(rotate));
            _animator = _character.GetComponent<Animator>();
            _photonView = _character.GetPhotonView();
            
            characters.Add(_character);

            _services = services;
            _state = new State(characterObject.stateObject);
        }

        public void Shoot(bool value)
        {
            if(!_photonView.IsMine)
            {
                return;
            }
            
            var current = _animator.GetBool(IsShoot);

            if(!current.Equals(value))
            {
                _animator.SetBool(IsShoot, value);
            }
        }

        public void Victory()
        {
            if(!_photonView.IsMine)
            {
                return;
            }
            _animator.SetTrigger(IsWin);
        }

        public void HasDamage()
        {
            if(!_photonView.IsMine)
            {
                return;
            }
            _animator.SetTrigger(HasHit);
            // _animator.ResetTrigger(HasHit);
        }

        public void Defeat()
        {
            if(!_photonView.IsMine)
            {
                return;
            }
            if(_state.IsDead)
            {
                _animator.SetTrigger(IsDefeat);
            }
        }

        public GameObject GetGameObject()
        {
            return _character;
        }

        public State GetState()
        {
            return _state;
        }
    }
}