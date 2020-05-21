using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class WorldSystem : System, IAwakeSystem
    {
        private readonly GameContext _context;
        
        public WorldSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        public void Awake()
        {
            _context.ActivePosition = Object.Instantiate(_context.DiceObject.activePosition).transform;
            _context.HidePosition = Object.Instantiate(_context.DiceObject.hidePosition).transform;
        }
    }
}