using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : UIBase {
    private void Awake()
    {
        Bind(UIEvent.LOADING_SCENE
//                UIEvent.LOADING_SCENE_02,
//                UIEvent.LOADING_SCENE_03,
//                UIEvent.LOADING_SCENE_04,
//                UIEvent.LOADING_SCENE_05,
//                UIEvent.LOADING_SCENE_06
            );
    }
    // Use this for initialization
    void Start () {
        setObjectActive(false);
	}
	
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case UIEvent.LOADING_SCENE:
                setObjectActive((bool)message);
                GetComponent<TweenAlpha>().PlayForward();
                break;
            default:
                break;
        }
    }
}
