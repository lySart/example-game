using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates {GUARD, PATROL, CHASE, DEAD }
[RequireComponent(typeof(NavMeshAgent))] //判斷如沒component將自動添加
public class EnemyController : MonoBehaviour
{
    public EnemyStates enemyStates;
    private NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        SwitchStates();
    }

    void SwitchStates()
    {
        switch (enemyStates)
        {
            case EnemyStates.GUARD:
                break;

            case EnemyStates.PATROL:
                break;

            case EnemyStates.CHASE:
                break;

            case EnemyStates.DEAD:
                break;
        }
    }
}
