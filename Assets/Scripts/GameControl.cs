using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEngine.U2D;
/// <summary>
/// 游戏管理类
/// </summary>
public class GameControl : MonoBehaviour
{
    public static GameControl Instance = null;
    public Root r;                         // 存储JSon数据

    /// <summary>
    /// Start方法，游戏入口
    /// </summary>
    void Start()
    {
        Instance = this;
        // 获取Json中的数据
        GetJson();
    }
    
    /// <summary>
    /// 从json文件中获取数据
    /// </summary>
    private void GetJson()
    {   
        StreamReader streamreader = new StreamReader( Application.streamingAssetsPath+Constants.JSON_PATH);//读取数据，转换成数据流
        JsonReader js = new JsonReader(streamreader);//再转换成json数据
        r = new Root();
        r = JsonMapper.ToObject<Root>(js);//读取
    }

    

}
