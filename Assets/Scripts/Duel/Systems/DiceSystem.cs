using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using UnityEngine;


namespace Duel.Systems
{
    public class DiceSystem : IUpdateSystem
    {
        private GameContext _context;
        private Dice _dice;
        
        public DiceSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Update()
        {
            if (_context.NeedThrow)
            {
                
            }
        }
    }
}