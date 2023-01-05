using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();
    public List<GameObject> pos = new List<GameObject>();
    public float speed;

    IEnumerator ItemCreate()
    {
        while (true)
        {
            if (MainCharactor.instance.isDie)
            {
                StopCoroutine("ItemCreate");
            }
            Instantiate(itemList[Random.Range(0, itemList.Count)], pos[Random.Range(0, pos.Count)].transform.position, Quaternion.identity);
            speed = (Random.Range(1, 3) / GameManager.instance.speed) * 10;
            yield return new WaitForSeconds(speed);
        }
    }
}
