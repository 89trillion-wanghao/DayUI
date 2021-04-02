using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始按钮点击
/// </summary>
public class StartButtonClick : MonoBehaviour
{
    public GameObject dailyPanel;
    public GameObject bgImg;
    public GameView gameView;
    public Button startButton;
    void Start()
    {
        startButton.onClick.AddListener(OnClick);
    }
    /// <summary>
    /// 开始按钮的监听方法
    /// </summary>
    private void OnClick()
    {
        dailyPanel.SetActive(true);
        bgImg.SetActive(true);
        gameView.Init(GameControl.Instance.r);
    }
}
