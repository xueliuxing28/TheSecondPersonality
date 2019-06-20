using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6_EndPoint : GameLogicBase {

    private bool isFirstTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y - 0.1f, transform.localPosition.z), 0.5f);
                Invoke("OnShowWinPanel", 0.5f);
                //Camera.main.transform.DOMove(new Vector3(-1.5f, 8f, 5.7f), 2f);
                //  Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
            }
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
