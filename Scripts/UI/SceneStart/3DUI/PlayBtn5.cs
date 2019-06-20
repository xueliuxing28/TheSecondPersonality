using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn5 : UIBase {
    private UIButton playBtn;
    private void Awake()
    {
        //因为uiroot在start里隐藏
        playBtn = GetComponent<UIButton>();
        if (playBtn == null)
        {
            Debug.LogError("helpBtn为空");
            return;
        }
        playBtn.onClick.Add(new EventDelegate(OnPressPlay));
    }
    private void OnPressPlay()
    {
        Dispatch(AreaCode.SCENE, SceneEvent.FIGHT_SCENE_5, 5);
        //传送加载场景消息
        Dispatch(AreaCode.UI, UIEvent.LOADING_SCENE, true);
    }
}

