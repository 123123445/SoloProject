using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    private void Update()
    {
        if (transform.position.x <= -21.79)
        {
            transform.position = transform.position + new Vector3(43.58f, 0, 0);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.instance.speed);
        }
    }
}