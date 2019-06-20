using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl_Front : EnemyBase {

    // public Animator animator;
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private Vector3 direction = Vector3.forward;//移动方向
    public bool die = false;
    //private bool speedUp = false;//加速判断
    private bool turn;//转变方向
    private void Awake()
    {
        turn = false;
        Bind(EnemyEvent.MOVE);
        // Bind(CharacterEvent.MOVE);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            //MOVE方法需要放在update中执行，不能通过处理中心
            case EnemyEvent.MOVE:
                //  Debug.Log("enemy");
                if (gameObject.activeSelf)
                    Move();
                break;
                //             case CharacterEvent.TECHONLOGY_01:
                //                 break;
                //             case CharacterEvent.TECHONLOGY_02:
                //                 break;
        }
    }
    private void Move()
    {
        if (!isMove && !die)
        {  //前向旋转
            StopMove();
            if (CanMoveFwd())
            {
                isMove = true;
                // Debug.Log("enemy开始移动");
                endpos = new Vector3(this.transform.position.x + direction.x, this.transform.position.y + direction.y, this.transform.position.z + direction.z);
                transform.DOMove(endpos, 1.5f);
                Invoke("StopMove", 1.5f);
            }
        }
    }
    private void StopMove()
    {
        isMove = false;
        if (!CanMoveFwd())
        {
            if (!turn)
            {
                this.transform.rotation = Quaternion.LookRotation(Vector3.left);
            }
            else
            {
                this.transform.rotation = Quaternion.LookRotation(Vector3.right);
            }
            turn = !turn;
            direction = -direction;
        }
    }
    private bool CanMoveFwd()
    {
        RaycastHit hit;
        //因为模型坐标在底部，不用-1
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 dir = new Vector3(direction.x, direction.y - 1, direction.z);
        //  Debug.Log(transform.position);
        //  Debug.Log(dir);
        bool touched = Physics.Raycast(startPos, dir, out hit, 1.5f);
        //  Debug.Log(touched);
        //Debug.DrawLine(this.transform.position, endpos, Color.black,20f);
        if (touched && hit.transform.tag == "Cube")
        {
            return true;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {

        //也可以放在敌人脚本调用
        if (other.tag == "Player")
        {
            Debug.Log("die");
            //控制die=true
            Dispatch(AreaCode.CHARACTER, CharacterEvent.DIE, true);
        }

    }
}
