using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_MoveCube2 : GameLogicBase {
    public Transform Cubes;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE2);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE2:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        transform.DOLocalRotate(new Vector3(90, 0, 0), 2f);
        Invoke("RotateCube", 2f);
        //transform.DOMove(new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), 5f);
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
    }
    private void RotateCube()
    {
        Cubes.DOLocalRotate(new Vector3(-90, 0, 0), 2f);
    }
}
