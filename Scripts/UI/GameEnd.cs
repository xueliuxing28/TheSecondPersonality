using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameEnd : UIBase {
    private void Awake()
    {
        Bind(UIEvent.DIE);
    }
    // Use this for initialization
    void Start () {
        setObjectActive(false);
    }
	
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.DIE:
                setObjectActive((bool)message);
                break;
//             case UIEvent.DIE_RETURN:
//                 OnPressDieReturn();
//                 break;
//             case UIEvent.RESTART_GAME:
//                 OnRestartGame();
//                break;
            default:
                break;
        }
    }
//     private void OnPressDieReturn()
//     {
//         //Dispatch(AreaCode.UI, UIEvent.EXIT_FIGHT_SCENE_YES, true);
//         //加载场景
//         Dispatch(AreaCode.UI, UIEvent.LOADING_SCENE, true);
//         Dispatch(AreaCode.SCENE, SceneEvent.START_SCENE, 0);
//     }

}
