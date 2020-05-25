using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;


namespace Duel.Systems
{
    public class WeaponSystem : System, IAwakeSystem, IUpdateSystem
    {
        private Weapon _weapon;
        private readonly GameContext _context;
        
        public WeaponSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
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