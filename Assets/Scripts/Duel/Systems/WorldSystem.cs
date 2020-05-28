using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class WorldSystem : System, IAwakeSystem
    {
        #region Private data

        private readonly GameContext _context;

        #endregion


        #region ctor

        public WorldSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            // _context.ActivePosition = Object.Instantiate(_context.DiceObject.activePosition).transform;
            // _context.HidePosition = Object.Instantiate(_context.DiceObject.hidePosition).transform;
        }

        #endregion
    }
}