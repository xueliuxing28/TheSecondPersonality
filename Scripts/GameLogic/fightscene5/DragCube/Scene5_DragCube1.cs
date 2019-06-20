using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene5_DragCube1 : DragCube {
    public override void Start()
    {
        dir = Vector3.forward;
        transformName = "group1";
    }
//     public  override void  Update()
//     {
// //         if (!locked)
// //         {
// //             if (Input.GetMouseButtonUp(0))
// //             {
// //                 Debug.Log("按下");
// //                 if (CheckGameObject())
// //                 {
// //                     locked = true;
// //                     transform.DOMoveZ(this.transform.localPosition.z + dir, 1f);
// //                     Invoke("ReleaseLock", 1f);
// //                     dir = -dir;
// //                     // Debug.Log(offset);
// //                 }
// //             }
// //         }
//        
//     }
//     bool CheckGameObject()
//     {
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hitInfo;
//         bool touched = Physics.Raycast(ray, out hitInfo);
// //        Debug.Log(touched);
// //         if (touched)
// //             Debug.Log(hitInfo.transform.name);
//         //  Dispatch(AreaCode.CHARACTER, CharacterEvent.IS_MOVE, true);
//         if (!GameObject.FindWithTag("Player").GetComponent<CharacterCtrl>().IsMove())
//             if (touched && (hitInfo.transform.name =="group1"//||
// //                 hitInfo.transform.name == "group2"||
// //                 hitInfo.transform.name == "group3"||
// //                     hitInfo.transform.name == "group4"
//                     ))
//             {
//                 return true;
//             }
//        
//  //       Debug.Log("失败");
//         return false;
//     }
//     private void ReleaseLock()
//     {
//         locked = false;
//     }
}
