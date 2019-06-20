using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_EndPoint4 : GameLogicBase {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(1);
            transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z-0.1f), 0.5f);
            Invoke("OnShowWinPanel", 0.5f);
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
