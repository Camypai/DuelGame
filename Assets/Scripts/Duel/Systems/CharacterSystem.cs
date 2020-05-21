using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class CharacterSystem : System, IAwakeSystem, IUpdateSystem
    {
        private Character _character;
        private readonly GameContext _context;
        

        public CharacterSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        public void Awake()
        {
            _character = new Character(_context.CharacterObject, _services);
        }

        public void Update()
        {
            // Debug.Log(_context.FaceValue);
            _character.Shoot(_context.FaceValue.HasValue);
        }
    }
}