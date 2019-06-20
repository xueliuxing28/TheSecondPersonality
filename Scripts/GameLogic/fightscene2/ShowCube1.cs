using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShowCube1 : GameLogicBase
{
    public GameObject Door;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE2_END_POINT_1);
    }
    public override void Execute(int eventCode, object message)
    {
        switch(eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE2_END_POINT_1:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y +1f, transform.position.z), 5f);
        Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5,0.1f,2);
    }
}
