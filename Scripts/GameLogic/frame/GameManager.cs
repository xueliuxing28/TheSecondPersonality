using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ManagerBase {
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }

}
