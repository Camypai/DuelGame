using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class InputSystem : System, IUpdateSystem
    {
        public InputSystem(GameContext context, UsableServices services) : base(context, services)
        {
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