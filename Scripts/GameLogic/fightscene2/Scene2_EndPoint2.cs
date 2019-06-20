using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene2_EndPoint2 :GameLogicBase{
    private bool isFirstTime = true;
    public GameObject enemy3;
    public GameObject cube_move1;
    public GameObject cube_move2;
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
                Camera.main.transform.DOMove(new Vector3(-1f, 10.8f, 5.14f),1f);
                Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
                enemy3.SetActive(true);
                cube_move1.SetActive(true);
                cube_move2.SetActive(true);
                Invoke("PermitCharacterMove", 5.5f);
                Invoke("ChangeToNextState", 0.5f);
            }
        }
    }
    private void ChangeToNextState()
    {
        //开始显示第一波方块
        Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE2_END_POINT_2, true);
        isFirstTime = false;
    }
    //封锁玩家移动
    private void PermitCharacterMove()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_PERMIT,true);
    }
}
