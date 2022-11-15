using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> obstacleList = new List<GameObject>();
    public Transform pos;

    private void Awake()
    {
        StartCoroutine("ObstacleCreate");
    }

    IEnumerator ObstacleCreate()
    {
        while (true)
        {
            Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], pos.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
