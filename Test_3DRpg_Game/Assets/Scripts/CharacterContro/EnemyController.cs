using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyStates {GUARD, PATROL, CHASE, DEAD }
[RequireComponent(typeof(NavMeshAgent))] //判斷如沒component將自動添加
public class EnemyController : MonoBehaviour
{
    private EnemyStates enemyStates;
    private NavMeshAgent agent;
    private Animator anim;

    [Header("Basic Settings")]
    public float sightRadius; //敵人可視範圍

    public bool isGuard;
    private float speed;

    private GameObject attackTarget;

    //bool Animation
    bool isWalk, isChase, isFollow;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
    }
    void Start()
    {
        
    }

    void Update()
    {
        SwitchStates();
        SwitchAnimation();
    }

    void SwitchAnimation()
    {
        anim.SetBool("Walk", isWalk);
        anim.SetBool("Chase", isChase);
        anim.SetBool("Follow", isFollow);
    }

    void SwitchStates()
    {
        if (FoundPlayer())
        {
            enemyStates = EnemyStates.CHASE;
            //Debug.Log("FOUNDPLAYER");
        }

        switch (enemyStates)
        {
            case EnemyStates.GUARD:
                break;

            case EnemyStates.PATROL:
                break;

            case EnemyStates.CHASE:

                isWalk = false;
                isChase = true;

                agent.speed = speed;
                if (!FoundPlayer())
                {
                    //TODO: backToLastState
                    isFollow = false;
                    agent.destination = transform.position;
                }
                else
                {
                    isFollow = true;
                    agent.destination = attackTarget.transform.position;
                    
                }

                break;

            case EnemyStates.DEAD:
                break;
        }
    }

    bool FoundPlayer()
    {
        var collider = Physics.OverlapSphere(transform.position, sightRadius);

        foreach (var target in collider)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
            
    }
}
