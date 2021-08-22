using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        MousseManager.Instance.OnMouseClicked += MoveToTarget; 
    }

    void Update()
    {
        
    }

    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
