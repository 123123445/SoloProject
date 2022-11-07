using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public int nowHp;
    public int maxHp;
    public int speed;

    [SerializeField] Vector3 mousePosition;
    Camera _camera;

    NavMeshAgent agent;

    private void Awake()
    {
        nowHp = maxHp;
        agent = GetComponentInChildren<NavMeshAgent>();
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Vector3.one;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << LayerMask.NameToLayer("Floor");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("Floor");
                mousePosition = hit.point;
                agent.SetDestination(mousePosition);
                if(mousePosition == agent.gameObject.transform.position)
                {
                    Debug.Log("Stop");
                    agent.isStopped = true;
                }
            }
        }
    } 
}
