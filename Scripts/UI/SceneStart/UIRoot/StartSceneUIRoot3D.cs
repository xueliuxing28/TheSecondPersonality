using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneUIRoot3D : UIBase {
    private void Awake()
    {
        Bind(UIEvent.START_PRESS_STARTGAME, UIEvent.START_PRESS_HELP, UIEvent.START_PRESS_STARTGAME_ESC);
    }
    // Use this for initialization
    void Start () {
        setObjectActive(false);
	}
    private void Update()
    {
        //返回
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Dispatch(AreaCode.UI, UIEvent.START_PRESS_STARTGAME_ESC, true);
        }
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {

            //按下开始游戏
            case UIEvent.START_PRESS_STARTGAME:
                setObjectActive((bool)message);
                break;
            case UIEvent.START_PRESS_STARTGAME_ESC:
                setObjectActive(!(bool)message);
                break;
            default:
                break;
        }

    }
}
