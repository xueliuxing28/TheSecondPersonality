using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_EndPoint3 : GameLogicBase {
    private bool isFirstTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z-0.1f), 0.5f);

                //Camera.main.transform.DOMove(new Vector3(-1.5f, 8f, 5.7f), 2f);
                Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
                Invoke("PermitCharacterMove", 5f);
                Invoke("ChangeToNextState", 1f);
            }
        }
    }
    private void ChangeToNextState()
    {
        //开始显示第一波方块
        Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE3, true);
        isFirstTime = false;
    }
    //封锁玩家移动
    private void PermitCharacterMove()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_PERMIT, true);
    }
}
