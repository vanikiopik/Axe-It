using UnityEngine;

public class GuiHandler : MonoBehaviour
{
    #region Singleton

    public static GuiHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    #endregion
    
    public SliderController SliderController;
    public ScoreTextController ScoreText;
}
