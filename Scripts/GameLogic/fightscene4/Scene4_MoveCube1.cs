using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_MoveCube1 : GameLogicBase {
    public Transform parent;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE1);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE1:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y -3, transform.position.z), 5f);
        transform.SetParent(parent);
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
    }
}
