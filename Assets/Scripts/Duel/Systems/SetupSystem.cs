using Duel.Contexts;
using Duel.Interfaces;
using Duel.ScriptableObjects;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class SetupSystem : System, IAwakeSystem
    {
        public SetupSystem(GameContext context, UsableServices services) : base(context, services)
        {
        }
        
        public void Awake()
        {
            _context.DiceObject = Data.DiceObject;
            _context.CharacterObject = Data.CharacterObject;
            _context.WeaponObject = Data.WeaponObject;
        }
    }
}