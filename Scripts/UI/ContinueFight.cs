using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueFight : UIBase {
    private UIButton continueBtn;
    private void Awake()
    {
        Bind(UIEvent.RESTART_GAME);
        continueBtn = GetComponent<UIButton>();
        continueBtn.onClick.Add(new EventDelegate(OnRestartGame));
    }
    private void OnRestartGame()
    {
        //loading
        Dispatch(AreaCode.UI, UIEvent.LOADING_SCENE, true);
        //获取当前场景index
        int index = SceneManager.GetActiveScene().buildIndex+1;
        Dispatch(AreaCode.SCENE, index, index);
    }
}
