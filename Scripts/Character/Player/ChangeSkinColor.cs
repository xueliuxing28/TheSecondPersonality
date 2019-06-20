using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinColor : CharacterBase {
    public Material material_Blue;
    public Material material_Yellow;
    public Material material_Green;
    private void Awake()
    {
        Bind(CharacterEvent.CHANGE_SKIN_TO_BLUE, 
            CharacterEvent.CHANGE_SKIN_TO_YELLOW,
            CharacterEvent.CHANGE_SKIN_TO_GREEN);
    }
    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case CharacterEvent.CHANGE_SKIN_TO_BLUE:
                GetComponent<SkinnedMeshRenderer>().material = material_Blue;
                break;
            case CharacterEvent.CHANGE_SKIN_TO_YELLOW:
                GetComponent<SkinnedMeshRenderer>().material = material_Yellow;
                break;
            case CharacterEvent.CHANGE_SKIN_TO_GREEN:
                GetComponent<SkinnedMeshRenderer>().material = material_Green;
                break;
        }
    }
}
