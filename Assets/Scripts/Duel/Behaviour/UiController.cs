using Duel.Contexts;
using Duel.Enums;
using Duel.Services;
using Duel.Systems;
using UnityEngine;
using UnityEngine.UI;


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
            // selectMenu.SetActive(true);
            _menuContext.UiButton = UiButton.Play;
        }

        public void Exit()
        {
            _menuContext.UiButton = UiButton.Exit;
        }
        
        public void Back()
        {
            _menuContext.UiButton = UiButton.Back;
        }
        
        public void Select(GameObject select)
        {
            _menuContext.UiButton = UiButton.Select;
            _menuContext.SelectCharacter = select;
        }

        public void SelectButton(Button button)
        {
            _menuContext.SelectedButton = button;
        }
    }
}