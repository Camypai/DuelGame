using System;
using System.Collections.Generic;
using Duel.Contexts;
using Duel.Enums;
using Duel.Models;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace Duel.Behaviour
{
    public class SelectCharacterController : MonoBehaviour, IPunObservable, IPunOwnershipCallbacks
    {
        [SerializeField]
        private GameObject canvas;

        private MenuContext   _menuContext;
        private PhotonView    _photonView;
        private List<Button>  _buttons;
        private CharacterType _characterType = CharacterType.None;
        private bool          _playerSelected;
        private bool          _otherSelected;
        private bool          _isLoaded = false;

        private void Awake()
        {
            _menuContext = MenuContext.GetMenuContext();
            _buttons     = new List<Button>();
            _buttons.AddRange(canvas.GetComponentsInChildren<Button>());
            _photonView = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (!_isLoaded && PhotonNetwork.IsMasterClient && _playerSelected && _otherSelected)
            {
                PhotonNetwork.LoadLevel(3);
                _isLoaded = true;
            }

            switch (_menuContext.UiButton)
            {
                case UiButton.None:
                    break;
                case UiButton.Play:
                    break;
                case UiButton.Exit:
                    break;
                case UiButton.Back:
                    PhotonNetwork.LoadLevel(0);
                    PhotonNetwork.LeaveRoom();
                    break;
                case UiButton.Select:
                    _photonView.RequestOwnership();
                    var character = _menuContext.SelectedButton.gameObject.GetComponent<CharacterSelect>();
                    _characterType                         = character.CharacterType;
                    _menuContext.CharacterObject.character = _menuContext.SelectCharacter;
                    _playerSelected                        = true;
                    break;
                default:
                    break;
            }

            _menuContext.UiButton = UiButton.None;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // Debug.Log(_characterType);
                stream.SendNext(_characterType);
            }
            else
            {
                var characterType = (CharacterType) stream.ReceiveNext();
                // Debug.Log(characterType);
                foreach (var button in _buttons)
                {
                    // Debug.Log(button.name);
                    var characterSelect = button.GetComponent<CharacterSelect>();
                    if (characterSelect != null && characterSelect.CharacterType == characterType)
                    {
                        button.interactable = false;
                    }
                    else
                    {
                        button.interactable = true;
                    }
                }

                _otherSelected = true;
            }
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            targetView.TransferOwnership(requestingPlayer);
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
        }
    }
}