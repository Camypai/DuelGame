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
            var image = _context.Images.First(q => q.GetComponent<HealthBarModel>().playerType == playerType);
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

            if (Input.GetMouseButton(0))
            {
                Debug.Log("Click");
                Debug.Log(_context.Camera);
                var        ray = _context.Camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out var hit)) {
                    var objectHit = hit.transform;
            
                    var item = objectHit.GetComponent<ItemModel>();
                    if (item != null)
                    {
                        Debug.Log("Select");
                    }
                }
            }
        }

        #endregion
    }
}