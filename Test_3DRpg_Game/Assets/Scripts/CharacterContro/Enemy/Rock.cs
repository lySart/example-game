using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rock : MonoBehaviour
{
    public enum RockStates {HitEnemy, HitPlayer, HitNothing }  

    private Rigidbody rb;
    public RockStates rockStates;

    [Header("Basic Settings")]
    public float force;
    public int damage;
    public GameObject target;
    private Vector3 direction;
    public GameObject rockBreakEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.one;
        rockStates = RockStates.HitPlayer;
        FlyToTarget();

    }

     void FixedUpdate()
    {
        if (rb.velocity.magnitude < 1)
        {
            rockStates = RockStates.HitNothing;

        }
    }

    public void FlyToTarget()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>().gameObject;
        }

        direction = (target.transform.position - transform.position + Vector3.up).normalized; //實現石頭向上飛去所以+vector3.up向上的力
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        switch (rockStates)
        {
            case RockStates.HitPlayer:
                if (other.gameObject.CompareTag("Player"))
                {
                    other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                    other.gameObject.GetComponent<NavMeshAgent>().velocity = direction * force;

                    other.gameObject.GetComponent<Animator>().SetTrigger("Dizzy");
                    other.gameObject.GetComponent<CharacterStats>().TakeDamage(damage, other.gameObject.GetComponent<CharacterStats>());

                    rockStates = RockStates.HitNothing;
                }
                break;

            case RockStates.HitEnemy:
                if (other.gameObject.GetComponent<Golem>())
                {
                    var otherStats = other.gameObject.GetComponent<CharacterStats>();
                    otherStats.TakeDamage(damage, otherStats);
                    Instantiate(rockBreakEffect,transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                break;
        }
    }
}
