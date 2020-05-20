using Duel.Contexts;
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
        private UsableServices _services;
        
        [SerializeField]
        private Text log;
        
        private void Awake()
        {
            var menuContext = new MenuContext();
            _services = UsableServices.SharedInstance;
            _services.Initialize(menuContext);
            
            _menuSystem = new MenuSystem(menuContext, _services, log);
            
            _menuSystem.Awake();
        }

        public void Play()
        {
            _menuSystem.Play();
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
        //
        // private void Update()
        // {
        //     _menuSystem.Update();
        // }
        //
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