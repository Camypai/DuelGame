using Duel.Contexts;
using Duel.Services;
using Duel.Systems;
using UnityEngine;


namespace Duel.Behaviour
{
    public class GameController : MonoBehaviour
    {
        private GameSystem _gameSystem;
        private UsableServices _services;

        private void Awake()
        {
            var gameContext = new GameContext();
            _services = UsableServices.SharedInstance;
            
            _gameSystem = new GameSystem(gameContext, _services);
            
            _gameSystem.Awake();
        }

        private void Start()
        {
            _gameSystem.Start();
        }

        private void Update()
        {
            _gameSystem.Update();
        }

        private void FixedUpdate()
        {
            _services.Update();
            _services.Dispose();
            
            _gameSystem.FixedUpdate();
        }

        private void LateUpdate()
        {
            _gameSystem.LateUpdate();
        }
    }
}