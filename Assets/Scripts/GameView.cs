using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GameView : MonoBehaviour
{

    private SpriteAtlas atlas;                          // 存储UI的图集
    private Sprite[] soldierSprite;                     // 存储士兵Sprite的数组
    private Dictionary<string, Sprite> cardDic;         // 存储士兵的名称和Sprite的字典
    private Vector3[] cardsPos;                         // 卡片位置数组
    private CardPrefabItem go;                          // 卡片prefab的引用
    private Root r;
    
    public void Init(Root r)
    {

        // 保存数据
        this.r = r;
        
        // 加载UI图集
        GetUISprites();
        
        // 获取士兵的卡牌素材
        GetSoldierSprites();
        
        // 计算卡片的位置信息
        GetCardsPos();
        
        // 对卡牌进行初始化
        go = Resources.Load<CardPrefabItem>(Constants.CARD_PREFAB);
        InitCards();
    }
    
    /// <summary>
    /// 加载UI图集
    /// </summary>
    private void GetUISprites()
    {
        atlas = Resources.Load<SpriteAtlas>(Constants.UIATLAS_PATH);
    }
    
    /// <summary>
    /// 获取士兵的卡牌素材
    /// </summary>
    private void GetSoldierSprites()
    {
        soldierSprite = Resources.LoadAll<Sprite>(Constants.SOLDIER_SPRITES_PATH);
        cardDic = new Dictionary<string, Sprite>();
        foreach (var item in soldierSprite)
        {
            cardDic.Add(item.name,item);
        }
    }
    
    /// <summary>
    /// 计算卡片位置
    /// </summary>
    private void GetCardsPos()
    {
        cardsPos = new Vector3[6];
        int startX = 190;
        int startY = (int)(transform.position.y - 408);
        int disX = 350;
        int disY = 630;
        for(int i=0;i<cardsPos.Length;i++)
        {
            cardsPos[i].x = startX + disX * (i % 3);
            cardsPos[i].y = startY - disY * (i / 3);
        }
    }
    
    /// <summary>
    /// 初始化卡片
    /// </summary>
    private void InitCards()
    {
        int i = 0;
        for(;i<r.dailyProduct.Count;i++)
        {
            if(r.dailyProduct[i].type==2)
            {
                SetType2Card(i);
            }else if(r.dailyProduct[i].type == 3)
            {
                SetType3Card(i);
            }        
        }
        for(;i<cardsPos.Length;i++)
        {
            SetTypeNullCard(i);
        }
    }

    /// <summary>
    /// 设置类型2的卡片
    /// </summary>
    /// <param name="i">卡片ID</param>
    private void SetType2Card(int i)
    {
        CardPrefabItem cardItem = Instantiate(go, cardsPos[i], Quaternion.identity, this.transform.parent.transform);
        cardItem.cardPanelImg.sprite =atlas.GetSprite(Constants.COIN_BG_NAME);
        Color nowColoe;
        ColorUtility.TryParseHtmlString(Constants.COINS_TITLE_COLOR, out nowColoe);
        cardItem.titleText.color = nowColoe;
        cardItem.titleText.text = Constants.COINS_TEXT;
        cardItem.frameImg.sprite = atlas.GetSprite(Constants.COIN_FRANE_NAME);
        cardItem.cardImg.sprite = atlas.GetSprite(Constants.BIG_COIN_NAME);
        cardItem.numText.gameObject.SetActive(false);
        cardItem.levelText.gameObject.SetActive(false);
        cardItem.freeText.text = Constants.FREE_BTN_TEXT;
        cardItem.pricePanel.gameObject.SetActive(false);
        cardItem.unLockText.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 设置类型3的卡片
    /// </summary>
    /// <param name="i">卡片ID</param>
    private void SetType3Card(int i)
    {
        
        CardPrefabItem cardItem = Instantiate(go, cardsPos[i], Quaternion.identity, transform.parent.transform);
        cardItem.cardPanelImg.sprite = atlas.GetSprite(Constants.SOLDIER_BG_NAME);
        Color nowColoe;
        ColorUtility.TryParseHtmlString(Constants.SOLDIER_TITLE_COLOR, out nowColoe);
        cardItem.titleText.color = nowColoe;
        cardItem.titleText.text = Constants.SOLDIER_TITLE_TEXT;
        cardItem.frameImg.sprite = atlas.GetSprite(Constants.SOLDIER_FRAME_NAME);
        cardItem.cardImg.sprite = cardDic[r.dailyProduct[i].subType.ToString()];
        cardItem.numText.text=Constants.SOLDIER_NUM_TEXT+r.dailyProduct[i].num;
        cardItem.freeText.gameObject.SetActive(false);
        cardItem.priceText.text = r.dailyProduct[i].costGold.ToString();
        cardItem.unLockText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置空类型卡片
    /// </summary>
    /// <param name="i">卡片ID</param>
    private void SetTypeNullCard(int i)
    {
        CardPrefabItem cardItem = Instantiate(go, cardsPos[i], Quaternion.identity, this.transform.parent.transform);
        cardItem.cardPanelImg.sprite = atlas.GetSprite(Constants.SOLDIER_BG_NAME);
        cardItem.titleText.gameObject.SetActive(false);
        cardItem.frameImg.sprite = atlas.GetSprite(Constants.COIN_FRANE_NAME);
        cardItem.cardImg.sprite = atlas.GetSprite(Constants.LOCK_NAME);
        cardItem.cardImg.SetNativeSize();
        cardItem.numText.gameObject.SetActive(false);
        cardItem.levelText.gameObject.SetActive(false);
        cardItem.buyBtn.gameObject.SetActive(false);

    }
}
