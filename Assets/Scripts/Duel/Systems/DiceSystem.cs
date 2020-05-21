using Duel.Contexts;
using Duel.Entities;
using Duel.Interfaces;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class DiceSystem : System, IAwakeSystem, IUpdateSystem
    {
        private Dice _dice;
        private bool _isThrew = false;
        private readonly GameContext _context;
        
        public DiceSystem(Context context, UsableServices services) : base(context, services)
        {
            _context = _mainContext as GameContext;
        }

        public void Awake()
        {
            _dice = new Dice(_context.DiceObject, _context.ActivePosition, _context.HidePosition);
        }

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
                    Debug.Log($"Threw {faceValue}");
                    _isThrew = false;
                    _context.FaceValue = faceValue;
                }
            }
        }
    }
}