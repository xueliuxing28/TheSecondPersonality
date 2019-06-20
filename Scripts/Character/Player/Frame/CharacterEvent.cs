using System;
using System.Collections.Generic;



public static class CharacterEvent
{
    public const int MOVE = 0;//普通移动
    public const int TECHONLOGY_01 = 1;//技能1
    public const int TECHONLOGY_02 = 2;//技能2发送消息
    public const int SKILL_2_MOVE_TO_POINT = 10;//技能2执行
    public const int SKILL_2_SET_SKILL_FALSE = 11;//技能2失效
  //  public const int IS_MOVE= 13;//返回是否在移动
    public const int MOVE_PAUSE = 12;//停止移动
    public const int DIE = 3;//死亡
    public const int WIN = 4;//胜利
   
    //改变颜色
    public const int CHANGE_SKIN_TO_BLUE = 5;//蓝色
    public const int CHANGE_SKIN_TO_YELLOW= 6;//黄色
    public const int CHANGE_SKIN_TO_GREEN = 7;//绿色

    public const int MOVE_FORBID = 8;//禁止角色移动
    public const int MOVE_PERMIT = 9;//允许角色移动

}
