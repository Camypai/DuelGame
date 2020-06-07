using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;


namespace Duel.Systems
{
    public class WeaponSystem : System, IAwakeSystem, IUpdateSystem
    {
        #region Private data

        private Weapon _weapon;
        private readonly GameContext _context;

        #endregion


        #region ctor

        public WeaponSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            _weapon = new Weapon(_context.WeaponObject, _services);
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (_context.FaceValue.HasValue)
            {
                _weapon.Shoot(_context.FaceValue);
                _context.FaceValue = null;
            }
        }

        #endregion
    }
}