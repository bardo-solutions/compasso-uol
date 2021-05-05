using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform m_Player;
    [SerializeField] float m_Speed = 100f;
    [SerializeField] float m_DelayTime = 0.8f;

    readonly List<Vector3> m_Buffer = new List<Vector3>();
    bool m_IsRunning = false;

    public void OnKeyboardEvent(KeyboardEvent t)
    {
        switch (t)
        {
            case KeyboardEvent.Start:
                StartCoroutine(Run());
                break;
            case KeyboardEvent.Up:
                m_Buffer.Add(Vector3.forward);
                break;
            case KeyboardEvent.Down:
                m_Buffer.Add(Vector3.back);
                break;
            case KeyboardEvent.Left:
                m_Buffer.Add(Vector3.left);
                break;
            case KeyboardEvent.Right:
                m_Buffer.Add(Vector3.right);
                break;
            default:
                break;
        }
    }


    IEnumerator Run()
    {
        if (m_IsRunning)
        {
            yield break;
        }

        // Avoid interference with event listener.
        yield return new WaitForEndOfFrame();

        m_IsRunning = true;
        foreach (var displacement in m_Buffer)
        {
            var from = m_Player.position;
            var to = from + displacement;
            yield return StartCoroutine(LerpMove(from, to));
            yield return new WaitForSeconds(m_DelayTime);
        }

        m_Buffer.Clear();
        m_IsRunning = false;
    }

    IEnumerator LerpMove(Vector3 source, Vector3 target)
    {
        for (int i = 1; i <= 100; i++)
        {
            m_Player.position = Vector3.Lerp(source, target, i / 100f);
            yield return new WaitForSeconds(1f / m_Speed);
        }
    }
}
