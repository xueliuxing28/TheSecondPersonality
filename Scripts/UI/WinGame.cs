using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : UIBase
{
    private void Awake()
    {
        Bind(UIEvent.WIN_GAME);
    }
    // Use this for initialization
    void Start()
    {
        setObjectActive(false);
    }

    public override void Execute(int eventCode, object message)
    {
        switch(eventCode)
        {
            case UIEvent.WIN_GAME:
                setObjectActive((bool)message);
                break;
        }
    }

}
