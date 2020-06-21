using System.Linq;
using Duel.Contexts;
using Duel.Enums;
using Duel.Interfaces;
using Duel.Models;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class InputSystem : System, IAwakeSystem, IUpdateSystem
    {
        #region Private data

        private readonly GameContext _context;

        #endregion


        #region ctor

        public InputSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        #endregion


        #region Private methods

        private void UpdateState(PlayerType playerType, float value)
        {
            Debug.Log(_context.Images.Count);
            var image = _context.Images.First(q => q.GetComponent<HealthBar>().playerType == playerType);
            image.fillAmount = value / 100;
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            _context.State.HealthPointsNotify += UpdateState;
            _context.HealthPointsNotify       += UpdateState;
        }

        #endregion


        #region IUpdateSystem

        public void Update()
        {
            if (!_context.GameIsEnd && Input.GetKeyDown(KeyCode.Space))
            {
                _context.NeedThrow = true;
            }
        }

        #endregion
    }
}