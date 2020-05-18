using Duel.Contexts;
using Duel.Interfaces;
using Duel.ScriptableObjects;
using UnityEngine;


namespace Duel.Systems
{
    public class SetupSystem : IAwakeSystem
    {
        private readonly GameContext _context;
        
        public SetupSystem(GameContext context)
        {
            _context = context;
        }
        
        public void Awake()
        {
            _context.DiceObject = Data.DiceObject;
        }
    }
}