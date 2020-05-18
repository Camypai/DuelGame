using Duel.Contexts;
using Duel.Interfaces;
using UnityEngine;


namespace Duel.Systems
{
    public class CharacterSystem : IStartSystem, IUpdateSystem
    {
        private GameContext _context;
        
        public CharacterSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Start()
        {
            // Debug.Log("Start");
        }

        public void Update()
        {
            if (_context.FaceValue.HasValue)
            {
                // Debug.Log(_context.FaceValue.Value);
                _context.FaceValue = null;
            }
        }
    }
}