using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneHelpPanelCtrl : UIBase {
    
    private void Awake()
    {
        Bind(UIEvent.START_PRESS_HELP, UIEvent.START_PRESS_HELP_ESC);
    }
    void Start () {
        setObjectActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	   if(Input.GetKeyDown(KeyCode.Escape))
        {
            Dispatch(AreaCode.UI, UIEvent.START_PRESS_HELP_ESC, true);
        }
	}
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
           
            //按下帮助
            case UIEvent.START_PRESS_HELP:
                setObjectActive((bool)message);
                break;
                //返回
            case UIEvent.START_PRESS_HELP_ESC:
                setObjectActive(!(bool)message);
                break;
            default:
                break;
        }
    }

}
