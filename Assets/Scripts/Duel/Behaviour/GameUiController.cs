using System.Linq;
using Duel.Contexts;
using Duel.Enums;
using Duel.Models;
using UnityEngine;


namespace Duel.Behaviour
{
    public class GameUiController : MonoBehaviour
    {
        private GameContext _gameContext;
        
        private void Awake()
        {
            _gameContext = GameContext.GetGameContext();
        }

        public void Roll()
        {
            if(!_gameContext.GameIsEnd)
            {
                _gameContext.NeedThrow = true;
            }
        }

        public void UpdateHealthBar(PlayerType playerType, float value)
        {
            var image = _gameContext.Images.First(q => q.GetComponent<HealthBarModel>().playerType == playerType);
            image.fillAmount = value / 100;
        }
    }
}