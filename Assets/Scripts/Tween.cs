using System.Collections;
using UnityEngine;

// Our custom tweening (dream of) library.
public static class Tween
{
    public static IEnumerator LerpMove(Transform transform, Vector3 source, Vector3 target, float duration)
    {
        float startTime = Time.time;
        float t = 0f;
        while (t < 1f)
        {
            t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(source, target, t);
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}