using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;


namespace Duel.Systems
{
    public class WorldSystem : System, IAwakeSystem, IUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;
        private bool _isLoaded = false;

        #endregion


        #region ctor

        public WorldSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            // _context.ActivePosition = Object.Instantiate(_context.DiceObject.activePosition).transform;
            // _context.HidePosition = Object.Instantiate(_context.DiceObject.hidePosition).transform;
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount < 2 && !_isLoaded)
            {
                _isLoaded = true;
                PhotonNetwork.LeaveRoom();
                PhotonNetwork.LoadLevel(0);
            }
        }

        #endregion
    }
}