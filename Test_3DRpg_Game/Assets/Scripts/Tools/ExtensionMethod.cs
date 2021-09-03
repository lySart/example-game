using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    private const float dotThreshokd = 0.5f; //+const變為常量是不可被更改的值(在static的class中去調用)

    public static bool IsFacingTarget(this Transform transform, Transform target)
    {
        var vectorToTarget = target.position - transform.position;
        vectorToTarget.Normalize(); //向量方向 正面1/左右0/後面-1

        float dot = Vector3.Dot(transform.forward, vectorToTarget);

        return dot >= dotThreshokd;
    }
}
