using System.Collections.Generic;
/// <summary>
/// 日常卡片数据的数据类
/// </summary>
public class DailyProductItem
{
    public int productId { get; set; }
    public int type { get; set; }
    public int subType { get; set; }
    public int num { get; set; }
    public int costGold { get; set; }

    public int isPurchased { get; set; }
}
/// <summary>
/// 日常卡片数据的集合类
/// </summary>
public class Root
{
    public List <DailyProductItem > dailyProduct { get; set; }
    
    public int dailyProductCountDown { get; set; }
}
