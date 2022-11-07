using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject _target;
    public int speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target.GetComponentInParent<Player>().nowHp--;
            Destroy(gameObject);
        }
    }
}
