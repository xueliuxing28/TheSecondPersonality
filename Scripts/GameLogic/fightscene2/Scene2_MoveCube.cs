using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene2_MoveCube : GameLogicBase
{
    private Vector3 dir;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE2_MOVE_CUBE);
    }
    public override void Execute(int eventCode, object message)
    {
        switch(eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE2_MOVE_CUBE:
                if(gameObject.activeSelf)
                    Move();
                break;
        }
    }
    private void Move()
    {
        if(transform.localPosition.x<-1.5f)
        {
            dir = Vector3.right;
        }
        else if (transform.localPosition.x > -0.5f)
        {
            dir = Vector3.left;
        }
        transform.DOMove(new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z),0.75f);
    }
}
