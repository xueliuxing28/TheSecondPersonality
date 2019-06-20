using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene5_DragCube2 : DragCube {
   
    public override void Start()
    {
        dir = Vector3.back;
        transformName = "group2";
}
}
