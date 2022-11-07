using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    void Update() {
    RaycastHit hit;
    float distance = 10f;
    int layerMask = 1 << LayerMask.NameToLayer("Floor");  // Player 레이어만 충돌 체크함
    if(Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, distance  ,layerMask)){
        Debug.Log("hit");
    }

    Debug.DrawRay(transform.position, transform.forward * 15, Color.red);
    }
}
