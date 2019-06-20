using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5_MoveCube2 : GameLogicBase {
    public Transform Cubes;
    public Transform group1;
    public Transform group2;
    public Transform group3;
    public Transform group4;
    public GameObject[] cube1;
    public GameObject[] cube2;
    public GameObject[] cube3;
    public GameObject[] cube4;
    public GameObject []enemy2;
    public GameObject[] enemy3;
    private void Awake()
    {
        Bind(GameLogicEvent.FIGHT_SCENE5_MOVE_CUBE2);
    }
    private void Start()
    {
        group1.gameObject.SetActive(false);
        group2.gameObject.SetActive(false);
        group3.gameObject.SetActive(false);
        group4.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case GameLogicEvent.FIGHT_SCENE5_MOVE_CUBE2:
                ShowCube();
                break;
        }
    }
    private void ShowCube()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < enemy2.Length; i++)
        {
            enemy2[i].SetActive(false);
        }
        //transform.DOLocalRotate(new Vector3(90, 0, 0), 2f);
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), 2f);
        Invoke("MoveCube", 2f);
        //Door.transform.DOMove(new Vector3(Door.transform.position.x, Door.transform.position.y + 2f, Door.transform.position.z), 5f);
        Camera.main.DOShakePosition(5, 0.1f, 2);
        Invoke("ResetParent", 3f);
    }
    private void MoveCube()
    {
        Cubes.DOLocalMove(new Vector3(0,1,0), 1f);
    }
    private void ResetParent()
    {
        for (int i = 0; i < enemy3.Length; i++)
        {
            enemy3[i].SetActive(true);
        }
        group1.gameObject.SetActive(true);
        group2.gameObject.SetActive(true);
        group3.gameObject.SetActive(true);
        group4.gameObject.SetActive(true);
        for (int i=0;i<4;i++)
        {
            cube1[i].transform.parent = group1;
            cube2[i].transform.parent = group2;
            cube3[i].transform.parent = group3;
            cube4[i].transform.parent = group4;
        }

    }
}
