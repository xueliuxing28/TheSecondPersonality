using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 存储所有的UI事件码
/// </summary>
public static class UIEvent
{
    //startscene
    public const int START_PRESS_ENTER = 0;//开始场景按下enter事件
    public const int START_PRESS_STARTGAME = 1;//按下开始游戏按键
    public const int START_PRESS_HELP = 2;//帮助按钮
    public const int START_PRESS_EXIT = 3;//退出游戏
    public const int START_PRESS_HELP_ESC = 4;//返回开始游戏面板
    public const int START_PRESS_STARTGAME_ESC = 5;//返回开始游戏面板返回

    //加载场景用于loading中
    public const int LOADING_SCENE = 6;

    /// <summary>
    /// 退出游戏
    /// </summary>
   //退出游戏关卡
    public const int EXIT_FIGHT_SCENE = 7;
    //退出游戏确认
    public const int EXIT_FIGHT_SCENE_YES = 8;
    //退出游戏返回
    public const int EXIT_FIGHT_SCENE_NO = 9;

    /// <summary>
    /// 死亡
    /// </summary>
    public const int DIE = 10;
    //返回开始面板
    public const int DIE_RETURN = 11;
    //重新开始
    public const int RESTART_GAME =12;


    /// <summary>
    /// 闯关成功
    /// </summary>
    //获胜
    public const int WIN_GAME = 13;


    public const int PROMPT_MSG = int.MaxValue;
}
