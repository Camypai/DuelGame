using Duel.Contexts;
using Duel.Systems;
using UnityEngine;


namespace Duel.Behaviour
{
    public class GameController : MonoBehaviour
    {
        private GameSystem _gameSystem;

        private void Awake()
        {
            var gameContext = new GameContext();
            _gameSystem = new GameSystem(gameContext);
            
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
            _gameSystem.FixedUpdate();
        }

        private void LateUpdate()
        {
            _gameSystem.LateUpdate();
        }
    }
}