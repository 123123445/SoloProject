using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMap : MonoBehaviour
{
    public GameObject teleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainCharactor.instance.isCanHit = false;
            if (MainCharactor.instance.shield)
            {
                MainCharactor.instance.shield = false;
            }
            else
            {
                MainCharactor.instance.nowHp--;
            }
            MainCharactor.instance.gameObject.transform.position = teleport.transform.position;
        }
    }
}
