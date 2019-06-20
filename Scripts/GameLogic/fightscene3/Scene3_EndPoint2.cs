using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_EndPoint2 : GameLogicBase {
    private bool isFirstTime = true;
    public GameObject player;
    public Transform playerParent;

    private void OnTriggerEnter(Collider other)
    {
        if (isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), 0.5f);
                Camera.main.transform.DOMove(new Vector3(-1.2f, 21.3f, -4.7f), 2f);
                Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
                changeParent();
                //        Dispatch(AreaCode.ENEMY, EnemyEvent.SEACTIVE_TRUE, true);
                // enemy1.SetActive(true);
                // enemy2.SetActive(true);
                Invoke("ReturnToParent", 7f);
                Invoke("PermitCharacterMove", 7);
                Invoke("ChangeToNextState", 2);
            }
        }
    }
    private void ChangeToNextState()
    {
        //开始显示第一波方块
        Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE3_MOVE_CUBE2, true);
        isFirstTime = false;
    }
    //封锁玩家移动
    private void PermitCharacterMove()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_PERMIT, true);
    }
    private void changeParent()
    {
        player.transform.parent = transform;
    }
    private void ReturnToParent()
    {
        player.transform.parent = playerParent;
    }
}
