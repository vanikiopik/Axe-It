namespace GUI.MoneyTableHUD
{
    [System.Serializable]
    public class MoneyTableHudController : UiController<MoneyTableHudView>
    {
        public bool Interactable
        {
            get => View.PlusButton.interactable;
            set => View.PlusButton.interactable = value;
        }
        
        public void MoneyText(int amount) => View.MoneyText.text = amount.ToString();

        public override void SetActive(bool isActive)
        {
            View.Background.gameObject.SetActive(isActive);
            View.MoneyText.gameObject.SetActive(isActive);
            View.PlusButton.gameObject.SetActive(isActive);
        }
    }
}
