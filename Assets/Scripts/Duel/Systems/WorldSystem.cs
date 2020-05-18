using Duel.Contexts;
using Duel.Interfaces;
using UnityEngine;


namespace Duel.Systems
{
    public class WorldSystem : IAwakeSystem
    {
        private readonly GameContext _context;

        public WorldSystem(GameContext context)
        {
            _context = context;
        }

        public void Awake()
        {
            _context.ActivePosition = Object.Instantiate(_context.DiceObject.activePosition).transform;
            _context.HidePosition = Object.Instantiate(_context.DiceObject.hidePosition).transform;
        }
    }
}