using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveDown : GameLogicBase {
    private bool hasMoved=false;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE5_MOVEDOWN_CUBE);
    }
    public override void Execute(int eventCode, object message)
    {
        switch(eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE5_MOVEDOWN_CUBE:
                if (hasMoved)
                    ReturnToStart();
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            transform.DOLocalMoveY(transform.localPosition.y - 1, 1f);
            hasMoved = true;
        }
    }
    private  void ReturnToStart()
    {
        transform.DOLocalMoveY(transform.localPosition.y + 1, 2f);
        hasMoved = false;
    }
}
