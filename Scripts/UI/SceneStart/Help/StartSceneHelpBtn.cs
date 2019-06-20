using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneHelpBtn : UIBase {
    private UIButton helpBtn;
    private void Awake()
    {
        Bind(UIEvent.START_PRESS_HELP, UIEvent.START_PRESS_HELP_ESC);
        //必须放在awake
        helpBtn = GetComponent<UIButton>();
        if (helpBtn == null)
        {
            Debug.LogError("helpBtn为空");
            return;
        }
        helpBtn.onClick.Add(new EventDelegate(OnPressHelp));
    }
    // Use this for initialization
    void Start () {
		
	}
    //点击事件
    private void OnPressHelp()
    {
        Dispatch(AreaCode.UI, UIEvent.START_PRESS_HELP, true);
    }
}
