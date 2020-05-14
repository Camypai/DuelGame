using Duel.Systems;
using UnityEngine;


namespace Duel.Behaviour
{
    public class GameController : MonoBehaviour
    {
        private readonly GameSystem _gameSystem = new GameSystem();

        private void Awake()
        {
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