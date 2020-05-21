using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class InputSystem : System, IUpdateSystem
    {
        private readonly GameContext _context;
        
        public InputSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _context.NeedThrow = true;
            }
        }
    }
}