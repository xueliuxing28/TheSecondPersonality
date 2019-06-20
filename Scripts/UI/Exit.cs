using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : UIBase {
    private void Awake()
    {
        Bind(UIEvent.EXIT_FIGHT_SCENE,UIEvent.EXIT_FIGHT_SCENE_NO);
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
            case UIEvent.EXIT_FIGHT_SCENE:
                setObjectActive((bool)message);         
                break;
            case UIEvent.EXIT_FIGHT_SCENE_NO:
                setObjectActive(!(bool)message);
                break;
            default:
                break;
        }
    }

}
