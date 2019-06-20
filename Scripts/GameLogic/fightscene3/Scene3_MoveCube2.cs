using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_MoveCube2 : GameLogicBase {
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE3_MOVE_CUBE2);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE3_MOVE_CUBE2:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y+6, transform.position.z), 5f);
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
    }
}
