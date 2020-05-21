using Duel.Contexts;
using Duel.Enums;
using Duel.Services;
using Duel.Systems;
using UnityEngine;


namespace Duel.Behaviour
{
    public class UiController : MonoBehaviour
    {
        private MenuContext _menuContext;
        
        private void Awake()
        {
            _menuContext = MenuContext.GetMenuContext();
        }
        
        public void Play(GameObject selectMenu)
        {
            selectMenu.SetActive(true);
        }

        public void Exit()
        {
            _menuContext.UiButton = UiButton.Exit;
        }
        
        public void Back(GameObject selectMenu)
        {
            selectMenu.SetActive(false);
        }
        
        public void Select(GameObject select)
        {
            _menuContext.UiButton = UiButton.Select;
            _menuContext.SelectCharacter = select;
        }
    }
}