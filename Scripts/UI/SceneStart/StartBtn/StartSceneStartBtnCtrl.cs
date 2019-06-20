using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneStartBtnCtrl : UIBase {
//     public  GameObject UIRoot_2D;
//     public  GameObject UIRoot_3D;
    public  UIButton startGameBtn;
    // Use this for initialization
    private void Awake()
    {
//         Bind(UIEvent.START_PRESS_ENTER,
//            UIEvent.START_PRESS_STARTGAME);
    }
    /// <summary>
    /// 注意，先注册事件，后隐藏，否则无法传输消息
    /// </summary>
    private void Start()
    {
        startGameBtn = GetComponent<UIButton>();
        if (startGameBtn == null)
        {
            Debug.LogError("startgameBtn为空");
            return;
        }
        startGameBtn.onClick.Add(new EventDelegate(OnPressStartGame));
        //UIRoot_2D = GameObject.Find("UI Root");
        //UIRoot_3D = GameObject.Find("UI Root (3D)");
//         if (UIRoot_3D == null)
//             Debug.LogError("UIRoot3D为空");
        //先找到后在隐藏
//         if(UIRoot_3D)
//         {
//             UIRoot_3D.SetActive(false);
//         }
       // setObjectActive(false);
    }
//     public override void Execute(int eventCode, object message)
//     {
//         switch (eventCode)
//         {
//             
//             //按下开始游戏
//             case UIEvent.START_PRESS_STARTGAME:
//                 //Transfer2D_To_3D((bool)message);
//                 OnPressStartGame();
//                 break;
//             default:
//                 break;
//         }
// 
//     }
    /// <summary>
    /// 按下开始游戏
    /// </summary>
    private void OnPressStartGame()
    {
        Dispatch(AreaCode.UI, UIEvent.START_PRESS_STARTGAME, true);
    }
}
