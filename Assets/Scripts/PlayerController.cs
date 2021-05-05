using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Target transform.")]
    [SerializeField] Transform m_Player;

    [Tooltip("Duration of each step animation in seconds.")]
    [SerializeField] float m_MoveTime = 1f;

    [Tooltip("Delay time between each step in seconds.")]
    [SerializeField] float m_DelayTime = 0.5f;

    // Auxiliar members.
    readonly List<Vector3> m_DisplacementBuffer = new List<Vector3>();
    bool m_IsRunning = false;

    public void OnKeyboardEvent(KeyboardEvent t)
    {
        if (m_IsRunning)
        {
            // Discard inputs while animation is running.
            return;
        }

        switch (t)
        {
            case KeyboardEvent.Start:
                StartCoroutine(Run());
                break;
            case KeyboardEvent.Up:
                m_DisplacementBuffer.Add(Vector3.forward);
                break;
            case KeyboardEvent.Down:
                m_DisplacementBuffer.Add(Vector3.back);
                break;
            case KeyboardEvent.Left:
                m_DisplacementBuffer.Add(Vector3.left);
                break;
            case KeyboardEvent.Right:
                m_DisplacementBuffer.Add(Vector3.right);
                break;
            default:
                break;
        }
    }

    IEnumerator Run()
    {
        if (m_IsRunning)
        {
            // Prevent coroutine overflow.
            yield break;
        }

        // Activate flag.
        m_IsRunning = true;

        foreach (var displacement in m_DisplacementBuffer)
        {
            // Iterate over displacement buffer.
            var from = m_Player.position;
            var to = from + displacement;

            // Wait for coroutine finishes before continue.
            yield return StartCoroutine(LerpMove(from, to));

            // Wait a little between each iteration.
            yield return new WaitForSeconds(m_DelayTime);
        }

        // Reset buffer.
        m_DisplacementBuffer.Clear();

        // Disable flag.
        m_IsRunning = false;
    }

    // TODO turn it into a custom Tweening library.
    IEnumerator LerpMove(Vector3 source, Vector3 target)
    {
        for (int i = 1; i <= 100; i++)
        {
            m_Player.position = Vector3.Lerp(source, target, i / 100f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
