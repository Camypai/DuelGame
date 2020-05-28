using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;


namespace Duel.Systems
{
    public class TurnSystem : System, IFixedUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;

        #endregion


        #region ctor

        public TurnSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IFixedUpdateSystem

        public void FixedUpdate()
        {
        }

        #endregion
    }
}