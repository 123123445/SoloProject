using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x <= -21.79)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.instance.speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && MainCharactor.instance.isCanHit == true)
        {
            MainCharactor.instance.isCanHit = false;
            MainCharactor.instance.nowHp--;
        }
    }
}
