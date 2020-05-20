using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;


namespace Duel.Systems
{
    public class WeaponSystem : System, IAwakeSystem, IUpdateSystem
    {
        private Weapon _weapon;
        
        public WeaponSystem(GameContext context, UsableServices services) : base(context, services)
        {
        }
        
        public void Awake()
        {
            _weapon = new Weapon(_context.WeaponObject);
        }

        public void Update()
        {
            if (_context.FaceValue.HasValue)
            {
                _weapon.Shoot(_context.FaceValue);
                _context.FaceValue = null;
            }
        }
    }
}