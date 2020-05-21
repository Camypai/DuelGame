using Duel.Contexts;
using Duel.Services;
using NotImplementedException = System.NotImplementedException;


namespace Duel.Systems
{
    public abstract class System
    {
        protected Context _mainContext;
        protected UsableServices _services;

        public System(Context context, UsableServices services)
        {
            _mainContext = context;
            _services = services;
        }

        protected System(UsableServices services)
        {
            
        }
    }
}