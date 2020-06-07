using Duel.Contexts;
using Duel.Helpers;
using Duel.Services;


namespace Duel.Systems
{
    public class GameSystem
    {
        #region Private data

        private readonly SystemCollection _systemCollection = new SystemCollection();

        #endregion


        #region ctor

        public GameSystem(Context context, UsableServices services)
        {
            _systemCollection.Add(new SetupSystem(context, services));
            _systemCollection.Add(new WorldSystem(context, services));
            _systemCollection.Add(new DiceSystem(context, services));
            _systemCollection.Add(new CharacterSystem(context, services));
            _systemCollection.Add(new WeaponSystem(context, services));
            _systemCollection.Add(new StatusSystem(context, services));
            _systemCollection.Add(new InputSystem(context, services));
        }

        #endregion


        #region Public methods

        public void Awake()
        {
            foreach (var awakeSystem in _systemCollection.AwakeSystems)
            {
                awakeSystem.Awake();
            }
        }

        public void Start()
        {
            foreach (var startSystem in _systemCollection.StartSystems)
            {
                startSystem.Start();
            }
        }

        public void Update()
        {
            foreach (var updateSystem in _systemCollection.UpdateSystems)
            {
                updateSystem.Update();
            }
        }

        public void FixedUpdate()
        {
            foreach (var fixedUpdateSystem in _systemCollection.FixedUpdateSystems)
            {
                fixedUpdateSystem.FixedUpdate();
            }
        }

        public void LateUpdate()
        {
            foreach (var lateUpdateSystem in _systemCollection.LateUpdateSystems)
            {
                lateUpdateSystem.LateUpdate();
            }
        }

        #endregion
    }
}