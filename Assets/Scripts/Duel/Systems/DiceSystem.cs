using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;
using Photon.Pun;
using UnityEngine;


namespace Duel.Systems
{
    public class DiceSystem : System, IAwakeSystem, IStartSystem, IUpdateSystem
    {
        #region Private data

        private Dice _dice;
        private bool _isThrew = false;
        private readonly GameContext _context;
        private PhotonView _photonView;

        #endregion


        #region ctor

        public DiceSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            _dice = new Dice(_context.DiceObject);
            _photonView = _dice.GetGameObject().GetPhotonView();
        }

        #endregion


        #region IStartSystem

        public void Start()
        {
            if (!_photonView.IsMine)
            {
                var dice = _dice.GetGameObject();
                dice.GetComponentInChildren<MeshRenderer>().materials[0] = _context.DiceObject.otherDice;
            }
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (_context.NeedThrow && !_isThrew)
            {
                _context.NeedThrow = false;
                _isThrew = true;
                _dice.BackToTheHidePosition();
            }

            if (_isThrew)
            {
                // Debug.Log("Throwing");
                var faceValue = _dice.Throw();
                if(faceValue.HasValue)
                {
                    // Debug.Log($"Threw {faceValue}");
                    _isThrew = false;
                    _context.FaceValue = faceValue;
                }
            }
        }

        #endregion
    }
}