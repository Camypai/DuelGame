using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;


namespace Duel.Systems
{
    public class CharacterSystem : System, IAwakeSystem, IStartSystem, IUpdateSystem
    {
        #region Private data

        private Character _character;
        private PhotonView _photonView;
        private readonly GameContext _context;

        #endregion


        #region ctor

        public CharacterSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            _character = new Character(_context.CharacterObject, _context.SpawnPositionsObject, _services, _context.Characters);
            _photonView = _character.GetGameObject().GetPhotonView();
        }

        #endregion


        #region IStartSystem

        public void Start()
        {
            if (!_photonView.IsMine)
            {
                var character = _character.GetGameObject();
                character.GetComponent<MeshRenderer>().material = null;
            }
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            // Debug.Log(_context.Characters.Count);
            _character.Shoot(_context.FaceValue.HasValue);
        }
        

        #endregion
    }
}