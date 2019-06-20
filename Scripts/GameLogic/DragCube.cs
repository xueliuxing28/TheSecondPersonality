using DG.Tweening;
using UnityEngine;

public class DragCube : GameLogicBase {
    protected Vector3 dir;
    protected bool locked=false;
    protected string transformName;
    // Use this for initialization
    public virtual void Start () {
        transformName = null;
        dir = Vector3.zero;
    }
	public virtual void Update () {
        if (!locked)
        {
            if (Input.GetMouseButtonUp(0))
            {
                //   Debug.Log("按下");
                if (CheckGameObject())
                {
                    locked = true;
                    transform.DOLocalMove(new Vector3(transform.localPosition.x+dir.x,
                        transform.localPosition.y+dir.y, transform.localPosition.z+dir.z),1f);
                  //  transform.DOMoveZ(this.transform.localPosition.z + dir, 1f);
                    Invoke("ReleaseLock", 1f);
                    dir = -dir;
                    // Debug.Log(offset);
                }
            }
        }
    }
  public   bool CheckGameObject()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool touched = Physics.Raycast(ray, out hitInfo);
        if (!GameObject.FindWithTag("Player").GetComponent<CharacterCtrl>().IsMove())
            if (touched && (hitInfo.transform.name ==transformName))
            {
                gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                return true;
            }
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        //       Debug.Log("失败");
        return false;
    }
    public  void ReleaseLock()
    {
        locked = false;
    }
}
