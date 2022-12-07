using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{ 
    private void Update()
    {
        if (transform.position.x <= -25)
        {
            transform.position = transform.position + new Vector3(40, 0, 0);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.instance.speed);
        }
    }
}
