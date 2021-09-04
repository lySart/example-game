using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Basic Settings")]
    public float force;
    public GameObject target;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FlyToTarget();

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
}
