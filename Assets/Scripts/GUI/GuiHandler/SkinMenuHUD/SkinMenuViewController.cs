using GUI.GuiHandler.SkinMenuHUD.SkinViews.Container;
using UnityEngine.Events;

namespace GUI.GuiHandler.SkinMenuHUD
{
    [System.Serializable]
    public class SkinMenuViewController : UiController<SkinMenuView>
    {
        private AxeViewContainer _axeContainer;
        private ThemeViewContainer _themeContainer;

        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            _axeContainer = View.AxeScrollView.content.GetComponent<AxeViewContainer>();
            _themeContainer = View.ThemeScrollView.content.GetComponent<ThemeViewContainer>();
            _axeContainer.Initialize(Gui.MoneyCounter);
            _themeContainer.Initialize(Gui.MoneyCounter);
            
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.AxeButton.onClick.AddListener(OnAxesButtonClick);
            View.ThemeButton.onClick.AddListener(OnThemesButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Gui.SkinMenuViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }

        private void OnAxesButtonClick()
        {
            View.ThemeScrollView.gameObject.SetActive(false);
            View.ThemeOutline.enabled = false;
            View.AxeScrollView.gameObject.SetActive(true);
            View.AxeOutline.enabled = true;
        }

        private void OnThemesButtonClick()
        {
            View.AxeScrollView.gameObject.SetActive(false);
            View.AxeOutline.enabled = false;
            View.ThemeScrollView.gameObject.SetActive(true);
            View.ThemeOutline.enabled = true;
        }
    }
}