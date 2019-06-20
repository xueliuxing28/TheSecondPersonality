using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneEnterCtrl : UIBase {

    // Use this for initialization
    private void Awake()
    {
        //开始UIRoot面板
        Bind(UIEvent.START_PRESS_ENTER,
            UIEvent.START_PRESS_STARTGAME);
        //UIRoot3D面板
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            OnPressEnter();
        }
	}
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.START_PRESS_ENTER:
                setObjectActive(!(bool)message);
                break;
            default:
                break;
        }

    }
    private void OnPressEnter()
    {
        Dispatch(AreaCode.UI, UIEvent.START_PRESS_ENTER, true);
    }
}
