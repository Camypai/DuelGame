using Duel.Helpers;


namespace Duel.Systems
{
    public class GameSystem
    {
        #region Private data

        private readonly SystemCollection _systemCollection = new SystemCollection();

        #endregion


        #region ctor

        public GameSystem()
        {
            _systemCollection.Add(new DiceSystem());
            _systemCollection.Add(new CharacterSystem());
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