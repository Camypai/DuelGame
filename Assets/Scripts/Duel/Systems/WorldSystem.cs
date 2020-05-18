using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class WorldSystem : System, IAwakeSystem
    {
        public WorldSystem(GameContext context, UsableServices services) : base(context, services)
        {
        }

        public void Awake()
        {
            _context.ActivePosition = Object.Instantiate(_context.DiceObject.activePosition).transform;
            _context.HidePosition = Object.Instantiate(_context.DiceObject.hidePosition).transform;
        }
    }
}