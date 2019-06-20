using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyActive : EnemyBase
{
    private void Awake()
    {
        Bind(EnemyEvent.SEACTIVE_TRUE);
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public override void Execute(int eventCode, object message)
    {
        switch(eventCode)
        {
            case EnemyEvent.SEACTIVE_TRUE:
                gameObject.SetActive(true);
                break;
        }
    }
}
