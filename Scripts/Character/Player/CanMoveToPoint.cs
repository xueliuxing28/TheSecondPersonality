using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveToPoint : MonoBehaviour {
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
            gameObject.SetActive(true);
    }
}
