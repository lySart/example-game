using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : EnemyController
{
    [Header("Skill")]

    public float kickForce = 25;
    public void KickOff()
    {
        if (attackTarget != null && transform.IsFacingTarget(attackTarget.transform))
        {
            var targetState = attackTarget.GetComponent<CharacterStats>();

            Vector3 direction = (attackTarget.transform.position - transform.position).normalized;
            //direction.Normalize();

            targetState.GetComponent<NavMeshAgent>().isStopped = true;
            targetState.GetComponent<NavMeshAgent>().velocity = direction * kickForce;
            targetState.GetComponent<Animator>().SetTrigger("Dizzy");

            targetState.TakeDamage(characterStats, targetState);
        }
    }
}
