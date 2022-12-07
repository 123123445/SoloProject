using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMap : MonoBehaviour
{
    private void Update()
    {   
        if (int.Parse(Score.instance.text.text) >= 100)
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.instance.speed);
        }
    }
}
