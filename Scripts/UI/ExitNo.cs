using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNo : UIBase {
    private UIButton exitNo;
    private void Awake()
    {
        Bind(UIEvent.EXIT_FIGHT_SCENE_YES);
        exitNo = GetComponent<UIButton>();
        exitNo.onClick.Add(new EventDelegate(OnPressExitNo));
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnPressExitNo()
    {
        Dispatch(AreaCode.UI, UIEvent.EXIT_FIGHT_SCENE_NO, true);
    }
}
