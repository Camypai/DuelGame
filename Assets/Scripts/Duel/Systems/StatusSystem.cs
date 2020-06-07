using System.Linq;
using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using NotImplementedException = System.NotImplementedException;


namespace Duel.Systems
{
    public class StatusSystem : System, IUpdateSystem
    {
        private readonly GameContext _context;
        
        public StatusSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        public void Update()
        {
            if (_context.GetStatuses.Any())
            {
                foreach (var status in _context.GetStatuses)
                {
                    status.SetState(_context.State);
                    _services.InvokeService.InvokeRepeating(status.Use, status.Time, status.Interval);
                }
                _context.GetStatuses.Clear();
                _context.TakeStatus = true;
            }
        }
    }
}