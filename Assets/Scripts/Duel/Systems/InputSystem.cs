using Duel.Contexts;
using Duel.Interfaces;
using UnityEngine;


namespace Duel.Systems
{
    public class InputSystem : IUpdateSystem
    {
        private GameContext _context;
        
        public InputSystem(GameContext context)
        {
            _context = context;
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