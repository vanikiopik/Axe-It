using GUI.GuiHandler.SkinMenuHUD.SkinViews;
using GUI.GuiHandler.SkinMenuHUD.SkinViews.Container;
using Skins;
using UnityEngine.Events;

namespace GUI.GuiHandler.SkinMenuHUD
{
    [System.Serializable]
    public class SkinMenuViewController : UiController<SkinMenuView>
    {
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.AxeScrollView.content.GetComponent<AxeViewContainer>().Initialize();
            View.ThemeScrollView.content.GetComponent<ThemeViewContainer>().Initialize();
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