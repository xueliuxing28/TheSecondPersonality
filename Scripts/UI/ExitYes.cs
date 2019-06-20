using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitYes : UIBase {
    private UIButton exitYes;
    private void Awake()
    {
        Bind(UIEvent.EXIT_FIGHT_SCENE_YES);
        exitYes = GetComponent<UIButton>();
        exitYes.onClick.Add(new EventDelegate(OnPressExitYes));
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//     public override void Execute(int eventCode, object message)
//     {
//         switch (eventCode)
//         {
//             case UIEvent.EXIT_FIGHT_SCENE_YES:
//                 //加载场景
// 
//                 //返回开始界面
//                 break;
//             default:
//                 break;
//         }
//     }
    private void OnPressExitYes()
    {
        //Dispatch(AreaCode.UI, UIEvent.EXIT_FIGHT_SCENE_YES, true);
        //加载场景
        Dispatch(AreaCode.UI, UIEvent.LOADING_SCENE, true);
        Dispatch(AreaCode.SCENE, SceneEvent.START_SCENE, 0);
    }
}
