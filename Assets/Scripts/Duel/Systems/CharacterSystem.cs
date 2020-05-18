using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class CharacterSystem : System, IAwakeSystem, IUpdateSystem
    {
        // private readonly GameContext _context;
        private Character _character;

        public CharacterSystem(GameContext context, UsableServices services) : base(context, services)
        {
        }

        public void Awake()
        {
            _character = new Character(_context.CharacterObject, _services);
        }

        public void Update()
        {
            if (_context.FaceValue.HasValue)
            {
                _character.Shoot();
                _context.FaceValue = null;
            }
        }
    }
}