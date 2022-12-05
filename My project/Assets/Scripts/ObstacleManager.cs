using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacleList = new List<GameObject>();
    public Transform pos;
    public float speed;

    private void Awake()
    {
        StartCoroutine("ObstacleCreate");
    }

    IEnumerator ObstacleCreate()
    {
        while (true)
        {
            if (MainCharactor.instance.isDie)
            {
                StopCoroutine("ObstacleCreate");
            }
            Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], pos.position, Quaternion.identity);
            speed = (Random.Range(1, 3) / GameManager.instance.speed) * 10;
            yield return new WaitForSeconds(speed);
        }
    }
}
