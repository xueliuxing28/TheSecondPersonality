using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCube : CharacterBase {
    //public Transform playerParent;
    //public Transform player;
    public   GameObject[] skillCube;
    private void Awake()
    {
        Bind(CharacterEvent.TECHONLOGY_02,CharacterEvent.SKILL_2_SET_SKILL_FALSE);
    }
    void Start () {
        // skillCube = GameObject.FindGameObjectsWithTag("skill2");
        for (int i = 0; i < skillCube.Length; i++)
        {
            skillCube[i].SetActive(false);
        }

    }
    void Update()
    {
        if (skillCube[0].activeSelf&&Input.GetMouseButtonDown(0))
        {
         //   Debug.Log("按下鼠标");
            //销毁刚体，影响射线检测，必须要immediate
            DestroyImmediate(GetComponent<Rigidbody>());

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool touched = Physics.Raycast(ray, out hitInfo);
          //  Debug.Log(touched);
          //  Debug.Log(hitInfo.transform.tag);
            if (touched && hitInfo.transform.tag == "skill2")
            {
               // Debug.Log("使用技能2");
                //发送消息至character
               // Debug.Log(hitInfo.transform.position);
                Dispatch(AreaCode.CHARACTER, CharacterEvent.SKILL_2_MOVE_TO_POINT,hitInfo.transform.position);
                //  gameObject.SetActive(false);
                for (int i = 0; i < skillCube.Length; i++)
                {
                    skillCube[i].SetActive(false);
                }
                //重新添加刚体
                gameObject.AddComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
                //重新回归
                // transform.parent = player;
                //Debug.Log(gameObject.activeSelf);
            }
        }
       // Debug.Log(gameObject.activeSelf);
    }
    public override void Execute(int eventCode, object message)
    {
       switch(eventCode)
        {
            case CharacterEvent.TECHONLOGY_02:
                for (int i = 0; i < skillCube.Length; i++)
                {
                    skillCube[i].SetActive(true);
                }
                break;
            case CharacterEvent.SKILL_2_SET_SKILL_FALSE:
                for (int i = 0; i < skillCube.Length; i++)
                {
                    skillCube[i].SetActive(false);
                }
                Debug.Log("wancheng");
                //因为子物体无法检测到射线        
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.tag == "Cube"||other.tag == "endPoint")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
//         if(!(other.transform.name=="moveCube"))
//         {
//             transform.parent = playerParent;
//         }
    }

}
