using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene1_EndPoint : UIBase {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(1);
            transform.DOMove(new Vector3(transform.position.x, transform.position.y -0.1f, transform.position.z), 0.5f);
            Camera.main.transform.DOMove(new Vector3(3.47f, 1.92f, 4.27f), 2f);
            Invoke("OnShowWinPanel", 2f);
        }
    }
    private void OnShowWinPanel()
    {
        //显示获胜UI
        Dispatch(AreaCode.UI, UIEvent.WIN_GAME, true);
        //使characterCtrl里的win为true
        Dispatch(AreaCode.CHARACTER, CharacterEvent.WIN, true);
    }
}
