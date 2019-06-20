using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5_MoveCube1 : GameLogicBase
{
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE5_MOVE_CUBE1);
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE5_MOVE_CUBE1:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        gameObject.SetActive(true);
        //transform.DOLocalRotate(new Vector3(90, 0, 0), 2f);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y+2, transform.position.z), 2f);
        
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
    }
}
