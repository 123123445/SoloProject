using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public int nowHp;
    public int maxHp;
    public int speed;

    public LayerMask layer;
    
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
        Debug.Log(_camera.ScreenToWorldPoint(mousePosition));
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Vector3.one;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,layer))
            {
                mousePosition = hit.point;
            }
            agent.SetDestination(mousePosition);
        }
    } 
}
