using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_DragCube2 : DragCube {
    public override void Start()
    {
        dir = Vector3.up;
        transformName = "moveCube2";
    }
    #region 方法1
    //     // private float offset;
    //     private Vector3 startMousePos;
    //     private bool PlayerCome = false;
    //     public Transform playerParent;
    //     public Transform enemyParent;
    //     private int startPoint = 6;
    //     private int endPoint = 5;
    //     private bool playerIsMove = false;
    // 
    //     void Update()
    //     {
    //         if (transform.localPosition.y<= startPoint && transform.localPosition.y >= endPoint)
    //         {
    //             if (Input.GetMouseButtonDown(0))
    //             {
    //                 Debug.Log("按下");
    //                 if (CheckGameObject())
    //                 {
    //                     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //                     RaycastHit hitInfo;
    //                     bool touched = Physics.Raycast(ray, out hitInfo);
    //                     if (touched)
    //                     {
    //                         startMousePos = hitInfo.point;
    //                         //offset = startMousePos.y - transform.localPosition.y;
    //                     }
    //                     // Debug.Log(offset);
    //                 }
    //             }
    //             if (Input.GetMouseButton(0))
    //             {
    //                 //  Debug.Log(1);
    //                 if (CheckGameObject())
    //                 {
    //                     Debug.Log("move");
    //                     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //                     RaycastHit hitInfo;
    //                     bool touched = Physics.Raycast(ray, out hitInfo);
    //                     Vector3 world_mousePosition = hitInfo.point;
    //                     float dis = world_mousePosition.y- startMousePos.y;
    //                     if (transform.localPosition.y <endPoint||transform.localPosition.y >startPoint)
    //                     {
    //                         Debug.Log("fanhui");
    //                         return;
    //                     }
    //                         
    //                     if (transform.localPosition.y <= startPoint && transform.localPosition.y >= endPoint)
    //                         transform.DOMoveY(startMousePos.y+ dis, 0.5f);
    //                 }
    //             }
    //         }
    //         else if (transform.localPosition.y > startPoint)
    //         {
    //             transform.localPosition = new Vector3(transform.position.x, startPoint, transform.localPosition.z);
    //         }
    //         else if (transform.localPosition.y <endPoint)
    //         {
    //             transform.localPosition = new Vector3(transform.position.x, endPoint, transform.localPosition.z);
    //         }
    // 
    //     }
    //     bool CheckGameObject()
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hitInfo;
    //         bool touched = Physics.Raycast(ray, out hitInfo);
    //         Debug.Log(touched);
    //         if (touched)
    //             Debug.Log(hitInfo.transform.name);
    //         //  Dispatch(AreaCode.CHARACTER, CharacterEvent.IS_MOVE, true);
    //         if (!GameObject.FindWithTag("Player").GetComponent<CharacterCtrl>().IsMove())
    //             if (touched && (hitInfo.transform.name == "moveCube" || PlayerCome))
    //             {
    //                 return true;
    //             }
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
    //             Debug.Log("enemy");
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
