using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneExitGame : MonoBehaviour {
    private UIButton exitBtn;
    // Use this for initialization
    private void Awake()
    {
        exitBtn = GetComponent<UIButton>();
        exitBtn.onClick.Add(new EventDelegate(OnPressExit));
    }
    private void OnPressExit()
    {
        Application.Quit();
    }
}
