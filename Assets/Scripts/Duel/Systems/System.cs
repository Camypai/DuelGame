using Duel.Contexts;
using Duel.Services;
using NotImplementedException = System.NotImplementedException;


namespace Duel.Systems
{
    public abstract class System
    {
        protected GameContext _context;
        protected UsableServices _services;

        public System(GameContext context, UsableServices services)
        {
            _context = context;
            _services = services;
        }

        protected System(UsableServices services)
        {
            
        }
    }
}