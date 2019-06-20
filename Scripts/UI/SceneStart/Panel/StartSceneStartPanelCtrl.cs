using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneStartPanelCtrl : UIBase {
    private void Awake()
    {
        Bind(UIEvent.START_PRESS_ENTER,
            UIEvent.START_PRESS_HELP,
            UIEvent.START_PRESS_HELP_ESC,
            UIEvent.START_PRESS_STARTGAME_ESC);
    }
    // Use this for initialization
    void Start () {
        setObjectActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            //按下回车
            case UIEvent.START_PRESS_ENTER:
                setObjectActive((bool)message);
                break;
            case UIEvent.START_PRESS_HELP:
                setObjectActive(!(bool)message);
                break;
            case UIEvent.START_PRESS_HELP_ESC:
                setObjectActive((bool)message);
                break;
            case UIEvent.START_PRESS_STARTGAME_ESC:
                setObjectActive((bool)message);
                break;
            default:
                break;
        }

    }
}
