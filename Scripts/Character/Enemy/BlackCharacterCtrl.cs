using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCharacterCtrl : CharacterBase {
    private Animator animator;
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private Vector3 direction;//移动方向
    private bool canMove=true;
    private void Awake()
    {
        Bind(CharacterEvent.MOVE, 
            CharacterEvent.MOVE_FORBID,
            CharacterEvent.MOVE_PERMIT);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            //MOVE方法需要放在update中执行，不能通过处理中心
            case CharacterEvent.MOVE:
                Walk((int)message);
                break;
        }
    }
    #region Walk
    void Walk(int inputCode)
    {
        if (!isMove)
        {
            isMove = true;
            switch (inputCode)
            {
                case 1:
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -1);
                    break;
                case 2:
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
                    break;
                case 3:
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
                    break;
                case 4:
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            if (direction != Vector3.zero)
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
            }
            if (isMove && CanWalkFwd())
            {
                animator.SetBool("walk", true);
                Dispatch(AreaCode.ENEMY, EnemyEvent.MOVE, true);
                //移动的方块
                Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE2_MOVE_CUBE, true);
                transform.DOMove(endpos, 1.5f);
                Invoke("StopWalk", 1.5f);
            }
            else
            {
                StopWalk();
            }
        }
    }
    private void StopWalk()
    {
        isMove = false;
        animator.SetBool("walk", false);
    }
    private bool CanWalkFwd()
    {
        RaycastHit hit;
        //因为模型坐标在底部，不用-1
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 dir = new Vector3(direction.x, direction.y - 1, direction.z);
//                  Debug.Log(startPos);
//                   Debug.Log(dir);
        bool touched = Physics.Raycast(startPos, dir, out hit, 1.5f);
        //Debug.DrawLine(startPos, endpos, Color.black,20f);
        if (touched && hit.transform.tag == "Cube")
        {
            return true;
        }
        Debug.Log("失败");
        return false;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy"|| other.tag == "Plane")
        {
            Debug.Log("die");
             gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        if(other.tag=="Player")
        {
            Dispatch(AreaCode.CHARACTER, CharacterEvent.DIE, true);
        }
    }
    public bool IsMove()
    {
        return isMove;
    }
}
