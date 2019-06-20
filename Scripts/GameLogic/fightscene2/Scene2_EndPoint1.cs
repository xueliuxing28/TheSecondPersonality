using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene2_EndPoint1 :GameLogicBase{
    private bool isFirstTime = true;
    public GameObject enemy1;
    public GameObject enemy2;
    // Use this for initialization
    void Start () {
		
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if(isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), 0.5f);
                Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
                //        Dispatch(AreaCode.ENEMY, EnemyEvent.SEACTIVE_TRUE, true);
                enemy1.SetActive(true);
                enemy2.SetActive(true);
                Invoke("PermitCharacterMove", 5.5f);
                Invoke("ChangeToNextState", 0.5f);
            }
        }
    }
    private void ChangeToNextState()
    {
        //开始显示第一波方块
        Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE2_END_POINT_1, true);
        isFirstTime = false;
    }
    //封锁玩家移动
    private void PermitCharacterMove()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_PERMIT,true);
        Debug.Log("zhixing允许移动");
    }
}
