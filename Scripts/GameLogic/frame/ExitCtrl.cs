using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCtrl : UIBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Dispatch(AreaCode.UI, UIEvent.EXIT_FIGHT_SCENE, true);
        }
	}
}
