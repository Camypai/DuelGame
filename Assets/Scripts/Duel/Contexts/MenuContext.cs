﻿using System.Runtime.InteropServices;
using Duel.Enums;
using UnityEngine;


namespace Duel.Contexts
{
    public class MenuContext : Context
    {
        #region Public data

        public UiButton UiButton = UiButton.None;
        public GameObject SelectCharacter;

        #endregion
        
        #region Private data

        private static MenuContext _menuContext;

        #endregion


        #region ctor

        private MenuContext()
        {
        }


        #endregion


        #region Public methods

        public static MenuContext GetMenuContext()
        {
            return _menuContext ?? (_menuContext = new MenuContext());
        }

        #endregion
    }
}