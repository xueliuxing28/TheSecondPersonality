using DG.Tweening;
using UnityEngine;

public class Scene4_EndPoint1 : GameLogicBase {
    private bool isFirstTime = true;
    public GameObject firstCube;
    public GameObject secondCube;
  //  public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.tag);
        if (isFirstTime)
        {
            if (other.tag == "Player")
            {
                transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), 0.5f);
                Camera.main.transform.DOMove(new Vector3(-1.5f, 8f, 5.7f), 1f);
                other.gameObject.transform.parent = transform;
                Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_FORBID, true);
                Invoke("PermitCharacterMove", 7f);
                Invoke("ChangeToNextState", 2f);
                Invoke("setCubeFalse", 1f);
            }
        }
    }
    private void ChangeToNextState()
    {
        //开始显示第一波方块
        Dispatch(AreaCode.GAME, GameLogicEvent.FIGHT_SCENE4_MOVE_CUBE1, true);
        isFirstTime = false;
    }
    //封锁玩家移动
    private void PermitCharacterMove()
    {
        Dispatch(AreaCode.CHARACTER, CharacterEvent.MOVE_PERMIT, true);
    }
    private void setCubeFalse()
    {
        firstCube.SetActive(false);
        secondCube.SetActive(true);
    }
}
