using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CharacterCtrl : CharacterBase {
    private Animator animator;
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private Vector3 direction;//移动方向
    private bool die = false;
    private bool win = false;
   // private bool speedUp = false;//加速判断
    private bool skill1 = false;//加速
    private bool skill2 = false;//瞬移
    private bool canUseSkill = false;//是否能使用技能
    private bool canMove=true;
    #region 
    //   public GameObject leftShoe;
    //    public GameObject rightShoe;     
    //     [SerializeField]
    //     private  GameObject leftCube;
    //     [SerializeField]
    //     private GameObject rightCube;
    //     [SerializeField]
    //     private GameObject frontCube;
    //     [SerializeField]
    //     private GameObject backCube;
    #endregion
    private void Awake()
    {
        Bind(CharacterEvent.MOVE, 
            CharacterEvent.TECHONLOGY_01,
            CharacterEvent.TECHONLOGY_02,
            CharacterEvent.DIE,
            CharacterEvent.WIN,
            CharacterEvent.MOVE_FORBID,
            CharacterEvent.MOVE_PERMIT,
            CharacterEvent.SKILL_2_MOVE_TO_POINT);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //只有停止移动时执行
        if(!isMove&&canMove)
        {
            //使用技能1
            if (skill1 && !skill2)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Dispatch(AreaCode.AUDIO, AudioEvent.PLAY_EFFECT_AUDIO, "skill");
                    canUseSkill = !canUseSkill;
                    Debug.Log("准备使用技能1");
                }
                if(canUseSkill)
                {
                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        // Debug.Log("按下D");
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.TECHONLOGY_01, 4);
            //            Debug.Log("D");
                        return;
                        // Move(4);
                    }
                    else if (Input.GetKeyUp(KeyCode.A))
                    {
                        // Debug.Log("按下A");
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.TECHONLOGY_01, 3);
                        return;
                        // Move(3);
                    }
                    else if (Input.GetKeyUp(KeyCode.W))
                    {
                        //Debug.Log("按下W");
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.TECHONLOGY_01, 1);
                        return;
                    }
                    else if (Input.GetKeyUp(KeyCode.S))
                    {
                        //Debug.Log("按下S");
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.TECHONLOGY_01, 2);
                        return;
                    }
                }              
            }
            //使用技能2
            else  if (!skill1 && skill2)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Dispatch(AreaCode.AUDIO, AudioEvent.PLAY_EFFECT_AUDIO, "skill");
                    Debug.Log("准备使用技能2");
                    canUseSkill = !canUseSkill;
                    if (canUseSkill)
                    {
                        //展示skillcube，发送至SkillCube
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.TECHONLOGY_02, true);
                    }
                    if (!canUseSkill)
                    {
                        //消失
                        Dispatch(AreaCode.CHARACTER, CharacterEvent.SKILL_2_SET_SKILL_FALSE, true);
                    }
                }
 
            }
            //普通模式
            if(!canUseSkill)
            {
                if (Input.GetKeyUp(KeyCode.D))
                {
                    // Debug.Log("按下D");
                    Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE, 4);
                    // Move(4);
                }
                else if (Input.GetKeyUp(KeyCode.A))
                {
                    // Debug.Log("按下A");
                    Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE, 3);
                    // Move(3);
                }
                else if (Input.GetKeyUp(KeyCode.W))
                {
                    //Debug.Log("按下W");
                    Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE, 1);
                }
                else if (Input.GetKeyUp(KeyCode.S))
                {
                    //Debug.Log("按下S");
                    Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE, 2);
                }
            }
        }
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            //MOVE方法需要放在update中执行，不能通过处理中心
            case CharacterEvent.MOVE:
                Walk((int)message);
                break;
            case CharacterEvent.TECHONLOGY_01:
                Run((int)message);
                break;
            case CharacterEvent.SKILL_2_MOVE_TO_POINT:
                Move((Vector3)message);
                break;
            case CharacterEvent.DIE:
                GameLost();
                break;
            case CharacterEvent.WIN:
                GameWin();
                break;
            case CharacterEvent.MOVE_FORBID:
                MoveForbid();
                break;
            case CharacterEvent.MOVE_PERMIT:
                MovePermit();
                break;
            case CharacterEvent.MOVE_PAUSE:
                StopMove();
                break;
        }
    }
    private void MoveForbid()
    {
        canMove = false;
    }
    private void MovePermit()
    {
        canMove = true;
    }
    #region 备用move
    //     void Move()
    //     {
    //         
    //         if (Input.GetKeyUp(KeyCode.D))
    //         {           
    //             if (!isMove && !die)
    //             {
    //                 direction = new Vector3(-1, 0, 0);
    //                 endpos = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
    //                 process = 0;
    //                 moveSpeed = 0.1f;
    //                 isMove = true;
    //             }
    //         }
    //        else if (Input.GetKeyUp(KeyCode.A))
    //         {
    //             if (!isMove && !die)
    //             {
    //                 direction = new Vector3(1, 0, 0);
    //                 endpos = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
    //                 process = 0;
    //                 moveSpeed = 0.1f;
    //                 isMove = true;
    //             }
    //         }
    //        else  if (Input.GetKeyUp(KeyCode.S))
    //         {           
    //             if (!isMove && !die)
    //             {
    //                 direction = new Vector3(0, 0, 1);
    //                 endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
    //                 process = 0;
    //                 moveSpeed = 0.1f;
    //                 isMove = true;
    //             }
    //         }
    //        else  if (Input.GetKeyUp(KeyCode.W))
    //         {
    //             if (!isMove && !die)
    //             {
    //                 direction = new Vector3(0, 0, -1);
    //                 endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
    //                 process = 0;
    //                 moveSpeed = 0.1f;
    //                 isMove = true;
    //             }
    //         }
    //         if (direction != Vector3.zero)
    //         {
    //             this.transform.rotation = Quaternion.LookRotation(direction);
    //         }
    // 
    //         if (isMove)
    //         {
    //             Debug.Log(2);
    //             process += Time.deltaTime * moveSpeed;
    //             Debug.Log(process);
    //             this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
    //             if (process >= 0.2)
    //             {
    //                 //animator.SetBool("isMove", true);
    //                 moveSpeed = 0.1f;
    //                 speedUp = false;
    //                 //                 leftShoe.SetActive(false);
    //                 //                 rightShoe.SetActive(false);
    //                 //  animator.SetBool("isMove", false);
    //                 isMove = false;
    //             }
    //         }
    //     }
    #endregion
    #region Walk
    void Walk(int inputCode)
    {
        if (!isMove && !die && !win)
        {
            isMove = true;
            switch (inputCode)
            {
                case 1:
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
                    //  Debug.Log(endpos);
                    break;
                case 2:
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
                    //  Debug.Log(endpos);
                    break;
                case 3:
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
                    //  Debug.Log(endpos);
                    //CanMove(leftCube.GetComponent<Cube2>());
                    break;
                case 4:
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
                    // Debug.Log(endpos);
                    //CanMove(rightCube.GetComponent<Cube3>());
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            if (direction != Vector3.zero)
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
            }
            //TODO
            if (isMove && CanWalkFwd())
            {
                animator.SetBool("walk", true);
                Dispatch(AreaCode.ENEMY, EnemyEvent.MOVE, true);
                //移动的方块
                Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE2_MOVE_CUBE, true);
                transform.DOMove(endpos, 1.5f);
                Invoke("StopWalk", 1.5f);
                #region 其他方法
                //             Debug.Log(2);
                //             process += Time.deltaTime*moveSpeed;
                //             Debug.Log(process);
                //             this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
                //             if (process>=0.2)
                //             {
                //                 //animator.SetBool("isMove", true);
                //                 moveSpeed = 0.1f;
                //                 speedUp = false;
                //                 //                 leftShoe.SetActive(false);
                //                 //                 rightShoe.SetActive(false);
                //                 //  animator.SetBool("isMove", false);
                //                 isMove = false;
                //            }
                #endregion
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
        if (touched)
        {
            Debug.Log(hit.point);
            Debug.Log(hit.collider.tag);
        }
        if (touched && hit.transform.tag == "Cube")
        {
            return true;
        }
        Debug.Log("失败");
        return false;
    }
    #endregion
    #region Run
    private void Run(int inputCode)
    {
        if (!isMove && !die && !win)
        {
            isMove = true;
            switch (inputCode)
            {
                case 1:
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
                    break;
                case 2:
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
                    break;
                case 3:
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
                    break;
                case 4:
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z);
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            if (direction != Vector3.zero)
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
            }
            if (isMove && CanRunFwd())
            {
                Debug.Log("可以使用技能，跑");
                animator.SetBool("run", true);
                Dispatch(AreaCode.ENEMY, EnemyEvent.MOVE, true);
                //移动方块
                Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE2_MOVE_CUBE, true);
                transform.DOMove(endpos, 2f);
                //关闭技能1,只能放在这,不能写在stoprun中
                skill1 = false;
                canUseSkill = false;
                Invoke("ChangeSkinToYellow", 2f);
                Invoke("StopRun", 2f);
            }
            else
            {
                StopRun();
            }
        }
    }
    private void ChangeSkinToYellow()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.CHANGE_SKIN_TO_YELLOW, true);
    }
    private void StopRun()
    {
        isMove = false;
        animator.SetBool("run", false);
    }
    private bool CanRunFwd()
    {
        RaycastHit hit;
        //因为模型坐标在底部，不用-1
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Vector3 dir = new Vector3(direction.x, direction.y - 1, direction.z);
        //          Debug.Log(startPos);
        //          Debug.Log(dir);
        bool touched = Physics.Raycast(startPos, dir, out hit, 3f);
        //Debug.DrawLine(startPos, endpos, Color.black,20f);
        //          Debug.Log(hit.point);
        //          Debug.Log(hit.collider.tag);
        if (touched && hit.transform.tag == "Cube")
        {
            return true;
        }
        return false;
    }
    #endregion
    #region Move
    void Move(Vector3 pos)
    {
        if (!isMove && !die && !win)
        {
            Debug.Log("move");
            Dispatch(AreaCode.CHARACTER, CharacterEvent.CHANGE_SKIN_TO_YELLOW, true);
            //消失方块
            Dispatch(AreaCode.CHARACTER, CharacterEvent.SKILL_2_SET_SKILL_FALSE, true);
            isMove = true;
            transform.position = pos;
            StopMove();
        }
    }
    private void StopMove()
    {
        isMove = false;
        canUseSkill = false;
    }
//     private bool CanMoveFwd()
//     {
//         RaycastHit hit;
//         //因为模型坐标在底部，不用-1
//         Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
//         Vector3 dir = new Vector3(direction.x, direction.y - 1, direction.z);
//         //          Debug.Log(startPos);
//         //          Debug.Log(dir);
//         bool touched = Physics.Raycast(startPos, dir, out hit, 1.5f);
//         //Debug.DrawLine(startPos, endpos, Color.black,20f);
//         //          Debug.Log(hit.point);
//         //          Debug.Log(hit.collider.tag);
//         if (touched && hit.transform.tag == "Cube")
//         {
//             return true;
//         }
//         return false;
//     }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="DieCube"|| other.tag == "Plane")
        {
            Debug.Log("die");
            Dispatch(AreaCode.CHARACTER, CharacterEvent.DIE, true);
        }
        //TODO
        //写在别的脚本里
//         if(other.tag == "endPoint")
//         {
//             GameWin();
//         }
        if (other.tag == "Door1")
        {
            skill1 = true;
            skill2 = false;
            Debug.Log("碰到了门1");
            Dispatch(AreaCode.CHARACTER, CharacterEvent.CHANGE_SKIN_TO_BLUE, true);
        }
        if (other.tag == "Door2")
        {
            skill2 = true;
            skill1 = false;
            Debug.Log("碰到了门2");
            Dispatch(AreaCode.CHARACTER, CharacterEvent.CHANGE_SKIN_TO_GREEN, true);
        }
    }
    /// <summary>
    /// 给UI发送消息
    /// </summary>
    private void GameLost()
    {
        die = true;
        Dispatch(AreaCode.UI, UIEvent.DIE, true);
    }
    //改用disptch调用
    private void GameWin()
    {
        win = true;
    }
    public bool IsMove()
    {
        return isMove;
    }
}
