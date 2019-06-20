using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ManagerBase {
    public static EnemyManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
}
