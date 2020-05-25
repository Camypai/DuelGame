using System;
using Duel.Contexts;
using Duel.Enums;
using Duel.Services;
using Duel.Systems;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


namespace Duel.Behaviour
{
    public class MainMenuController : MonoBehaviourPunCallbacks
    {
        private MenuSystem _menuSystem;
        private SetupSystem _setupSystem;
        private UsableServices _services;
        private MenuContext _menuContext;
        
        [SerializeField]
        private Text log;
        
        private void Awake()
        {
            _menuContext = MenuContext.GetMenuContext();
            _services = UsableServices.SharedInstance;
            _services.Initialize(_menuContext);
            
            _setupSystem = new SetupSystem(_menuContext, _services);
            _menuSystem = new MenuSystem(_menuContext, _services, log);
            
            _setupSystem.Awake();
            _menuSystem.Awake();
        }

        public override void OnConnectedToMaster()
        {
            _menuSystem.Connect();
        }

        public override void OnJoinedRoom()
        {
            _menuSystem.JoinedRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            _menuSystem.OnJoinRandomFailed(returnCode, message);
        }

        // private void Start()
        // {
        //     _menuSystem.Start();
        // }
        
        private void Update()
        {
            switch (_menuContext.UiButton)
            {
                case UiButton.None:
                    break;
                case UiButton.Play:
                    _menuSystem.Play();
                    break;
                case UiButton.Exit:
                    Application.Quit();
                    break;
                case UiButton.Back:
                    break;
                case UiButton.Select:
                    _menuSystem.Select();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _menuContext.UiButton = UiButton.None;
        }
        
        // private void FixedUpdate()
        // {
        //     _services.Update();
        //     _services.Dispose();
        //     
        //     _menuSystem.FixedUpdate();
        // }
        //
        // private void LateUpdate()
        // {
        //     _menuSystem.LateUpdate();
        // }
    }
}