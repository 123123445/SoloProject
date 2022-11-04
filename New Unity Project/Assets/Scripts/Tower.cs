using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{ 

    public float time;
    public float maxTime = 2;

    public int atkSpeed;

    public GameObject bullets;
    public GameObject pos;

    public GameObject target;
    public int speed;
    private void Update()
    {
        time += Time.deltaTime;
        TowerAtk();
    }

    public void TowerAtk()
    { 
        if (time >= maxTime && target != null)
        {
            GameObject bullet = Instantiate(bullets);
            bullet.transform.position = pos.transform.position;
            bullet.GetComponent<Bullets>()._target = target;
            time = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player µé¾î¿È");
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }
}
