using Duel.Contexts;
using Duel.Interfaces;
using Duel.ScriptableObjects;
using Duel.Services;
using UnityEngine;


namespace Duel.Systems
{
    public class SetupSystem : System, IAwakeSystem
    {
        #region ctor

        public SetupSystem(Context context, UsableServices services) : base(context, services)
        {
        }

        #endregion


        #region IAwakeSystem

        public void Awake()
        {
            _mainContext.DiceObject = Data.DiceObject;
            _mainContext.CharacterObject = Data.CharacterObject;
            _mainContext.WeaponObject = Data.WeaponObject;
            _mainContext.PositionsObject = Data.PositionsObject;
            _mainContext.WorldObject = Data.WorldObject;
        }

        #endregion        
    }
}