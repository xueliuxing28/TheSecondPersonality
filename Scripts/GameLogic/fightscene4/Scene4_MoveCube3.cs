using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_MoveCube3 : GameLogicBase {
    public Transform Cubes;
    public GameObject[] enemy2;
    public GameObject[] enemy3;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE3);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE3:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        Debug.Log("zhuindc");
        transform.DOLocalRotate(new Vector3(-90, 0, 0), 2f);
        Invoke("RotateCubes", 2f);
        //transform.DOMove(new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), 5f);
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
        Invoke("ShowEnemy", 4.5f);
        for (int i = 0; i < enemy2.Length; i++)
        {
            enemy2[i].SetActive(false);
        }
    }
    private void RotateCubes()
    {
        Cubes.DOLocalRotate(new Vector3(0, 0, 0), 2f);
    }
    private void ShowEnemy()
    {
        for (int i = 0; i < enemy3.Length; i++)
        {
            enemy3[i].SetActive(true);
        }
    }
}
