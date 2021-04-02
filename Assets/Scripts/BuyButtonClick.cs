using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 购买按钮点击
/// </summary>
public class BuyButtonClick : MonoBehaviour
{
    public GameObject purchasedImgGO;
    public GameObject purchasedTextGO;
    public Button buyBtn;
    void Start()
    {
        // 购买按钮添加点击监听
        buyBtn.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// 按钮点击监听方法
    /// </summary>
    private void OnClick()
    {
        purchasedImgGO.SetActive(true);
        purchasedTextGO.SetActive(true);
        gameObject.SetActive(false);
    }




}
