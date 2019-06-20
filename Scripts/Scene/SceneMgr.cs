using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneMgr : ManagerBase
{
    public static SceneMgr Instance = null;

    private void Awake()
    {
        Instance = this;
        Add(SceneEvent.START_SCENE, this);
        Add(SceneEvent.FIGHT_SCENE_1, this);
        Add(SceneEvent.FIGHT_SCENE_2, this);
        Add(SceneEvent.FIGHT_SCENE_3, this);
        Add(SceneEvent.FIGHT_SCENE_4, this);
        Add(SceneEvent.FIGHT_SCENE_5, this);
        Add(SceneEvent.FIGHT_SCENE_6, this);

    }
    /// <summary>
    /// message暂时没有使用，传入参数也是index
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case SceneEvent.START_SCENE:
                StartCoroutine(loadScene(SceneEvent.START_SCENE));
                break;
            case SceneEvent.FIGHT_SCENE_1:
                StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_1));
                break;
            case SceneEvent.FIGHT_SCENE_2:
              StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_2));
                break;
            case SceneEvent.FIGHT_SCENE_3:
               StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_3));
                break;
            case SceneEvent.FIGHT_SCENE_4:
              StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_4));
                break;
            case SceneEvent.FIGHT_SCENE_5:
               StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_5));
                break;
            case SceneEvent.FIGHT_SCENE_6:
                StartCoroutine(loadScene(SceneEvent.FIGHT_SCENE_6));
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneBuildIndex"></param>
     IEnumerator loadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(1);
        if (sceneIndex >= 0 && sceneIndex <= 6)
            SceneManager.LoadScene(sceneIndex);
    }

}

