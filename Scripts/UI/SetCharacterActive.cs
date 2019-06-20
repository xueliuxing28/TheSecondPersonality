using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacterActive : MonoBehaviour {

    public GameObject[] character;
    private void Start()
    {
        Invoke("SetActive", 3f);
    }
    private void SetActive()
    {
        for (int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(true);
        }
    }
}
