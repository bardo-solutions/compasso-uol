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
    [Tooltip("Player area size, in units.")]
    [SerializeField] int m_AreaSize = 4;
    private Vector2[] m_Bounds = new Vector2[2];

    // Auxiliar members.
    readonly List<Vector3> m_DisplacementBuffer = new List<Vector3>();
    bool m_IsRunning = false;
    private void Awake()
    {
        m_Bounds[0] = new Vector2(m_Player.position.x - m_AreaSize / 2f, m_Player.position.z - m_AreaSize / 2f);
        m_Bounds[1] = new Vector2(m_Player.position.z + m_AreaSize / 2f, m_Player.position.z + m_AreaSize / 2f);
    }

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
            Vector3 from = m_Player.position;
            Vector3 to;

            if (ClampPlayerBounds(from + displacement, out to))
            {
                // Wait for coroutine finishes before continue.
                yield return StartCoroutine(Tween.LerpMove(m_Player, m_Player.position, to, m_MoveTime));

                // Wait a little between each iteration.
                yield return new WaitForSeconds(m_DelayTime);
            }
        }

        // Reset buffer.
        m_DisplacementBuffer.Clear();
        // Disable flag.
        m_IsRunning = false;
    }

    bool ClampPlayerBounds(Vector3 value, out Vector3 target)
    {
        target = new Vector3(
            Mathf.Clamp(value.x, m_Bounds[0].x, m_Bounds[1].x),
            value.y,
            Mathf.Clamp(value.z, m_Bounds[0].y, m_Bounds[1].y)
        );
        return target == value;
    }
}
