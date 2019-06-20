using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour {
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("改变playerparent");
            other.transform.parent=transform;
        }
        if(other.tag == "Enemy")
        {
            Debug.Log("改变enemyparent");
            other.transform.parent = transform;
        }
    }
}
