using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5_EndPoint3:GameLogicBase {
    private bool isFirstTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y - 0.1f, transform.localPosition.z), 0.5f);
                Invoke("OnShowWinPanel", 2f);
                Camera.main.transform.DOMove(new Vector3(5.8f, 4.8f, 8.2f), 2f);
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
