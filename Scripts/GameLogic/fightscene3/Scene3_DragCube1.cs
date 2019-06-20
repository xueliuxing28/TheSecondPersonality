using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene3_DragCube1 : DragCube {
    public override void Start()
    {
        dir = Vector3.left;
        transformName = "moveCube1";
    }



    #region 方法1
    //     private float offset;
    //     private Vector3 startMousePos;
    //     private bool PlayerCome = false;
    //     public Transform playerParent;
    //     public Transform enemyParent;
    //     private bool playerIsMove=false;
    //     //float startPositionX;
    //     // Use this for initialization
    // 	
    // 	void Update () {
    //         if (transform.localPosition.x <=0.5f && transform.localPosition.x >= -0.5f)
    //         {
    //             if (Input.GetMouseButtonDown(0))
    //             {
    //                 Debug.Log("按下");
    //                 if (CheckGameObject())
    //                 {
    //                     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //                     RaycastHit hitInfo;
    //                     bool touched = Physics.Raycast(ray, out hitInfo);
    //                     if(touched)
    //                     {
    //                         startMousePos = hitInfo.point;
    //                         offset = startMousePos.x - transform.localPosition.x;
    //                     }
    //                    // Debug.Log(offset);
    //                 }
    //             }
    //             if (Input.GetMouseButton(0))
    //             {
    //               //  Debug.Log(1);
    //                 if (CheckGameObject())
    //                 {
    //                     Debug.Log("move");
    //                     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //                     RaycastHit hitInfo;
    //                     bool touched = Physics.Raycast(ray, out hitInfo);
    //                     Vector3 world_mousePosition = hitInfo.point;
    //                     float dis = world_mousePosition.x - startMousePos.x;
    //                     if ((offset < 0 && transform.localPosition.x <= -0.5f) || (offset > 0 && transform.localPosition.x >= 0.5f))
    //                         return;
    //                     if (transform.localPosition.x <=0.5f && transform.localPosition.x >= -0.5f)
    //                         transform.DOMoveX(startMousePos.x + dis, 0.5f);
    //                 }
    //             }
    //         }
    //         else if (transform.localPosition.x >0.5f)
    //         {
    //             transform.localPosition = new Vector3(0.5f, transform.localPosition.y, transform.localPosition.z);
    //         }
    //         else if (transform.localPosition.x < -0.5f)
    //         {
    //             transform.localPosition = new Vector3(-0.5f, transform.localPosition.y, transform.localPosition.z);
    //         }
    // 
    //     }
    //     bool CheckGameObject()
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hitInfo;
    //         bool touched = Physics.Raycast(ray, out hitInfo);
    //         Debug.Log(touched);
    //         if(touched)
    //           Debug.Log(hitInfo.transform.name);
    //       //  Dispatch(AreaCode.CHARACTER, CharacterEvent.IS_MOVE, true);
    //       if(!GameObject.FindWithTag("Player").GetComponent<CharacterCtrl>().IsMove())
    //         if (touched && (hitInfo.transform.name == "moveCube"||PlayerCome))
    //         {
    //             return true;
    //         }
    //         Debug.Log("失败");
    //         return false;
    //     }
    //     private void OnCollisionEnter(Collision collision)
    //     {
    //         if (collision.transform.tag == "Player")
    //         {
    //             // Debug.Log("player");
    //             StartCoroutine(setParent(collision.transform));
    //             //other.transform.parent = this.transform;
    //         }
    //         if (collision.transform.tag == "Enemy")
    //         {
    //              Debug.Log("enemy");
    //             StartCoroutine(setParent(collision.transform));
    //         }
    //     }
    //     private void OnCollisionStay(Collision collision)
    //     {
    //         if (collision.transform.tag == "Player")
    //         {
    //             PlayerCome = true;
    //         }
    //     }
    //     private void OnCollisionExit(Collision collision)
    //     {
    //         if (collision.transform.tag == "Player")
    //         {
    //             StartCoroutine(setPlayerParent_Exit(collision.transform));
    //             PlayerCome = false;
    //         }
    //         if (collision.transform.tag == "Enemy")
    //         {
    //             StartCoroutine(setEnemyParent_Exit(collision.transform));
    //         }
    //     }
    //     IEnumerator setParent(Transform t)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         t.parent = transform;
    //     }
    //     IEnumerator setPlayerParent_Exit(Transform t)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         t.transform.parent = playerParent;
    //     }
    //     IEnumerator setEnemyParent_Exit(Transform t)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         t.transform.parent = enemyParent;
    //     }
    #endregion

}
