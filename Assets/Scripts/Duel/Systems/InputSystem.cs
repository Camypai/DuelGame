using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class InputSystem : System, IUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;

        #endregion


        #region ctor

        public InputSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _context.NeedThrow = true;
            }
        }

        #endregion        
    }
}