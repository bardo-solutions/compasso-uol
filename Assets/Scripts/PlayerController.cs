using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int[] m_gridSize = new int[2];
    [SerializeField]
    private int m_step;
    [SerializeField]
    private float m_speed;
    private Vector2 m_onGridPosition;
    [SerializeField]
    private Transform m_player;
    private bool m_enabled = false;


    void OnEnable()
    {
        EventListener.OnKeyboardEvent.AddListener(OnKeyboardEvent);
        m_onGridPosition = new Vector2((m_gridSize[0] - 1 / 2f), (m_gridSize[1] - 1) / 2f);
    }

    void OnDisable()
    {
        EventListener.OnKeyboardEvent.RemoveListener(OnKeyboardEvent);
    }

    void OnKeyboardEvent(KeyboardEvent t)
    {
        if (t == KeyboardEvent.Start)
            m_enabled = true;

        if (!m_enabled)
            return;

        switch (t)
        {
            case KeyboardEvent.Up:
                Move(Vector2.up);
                break;
            case KeyboardEvent.Down:
                Move(Vector2.down);
                break;
            case KeyboardEvent.Left:
                Move(Vector2.left);
                break;
            case KeyboardEvent.Right:
                Move(Vector2.right);
                break;
            default:
                return;
        }
    }

    void Move(Vector2 dir)
    {
        Vector3 currentPos = m_player.position;
        Vector3 targetPos = new Vector3(
            Mathf.Clamp(m_onGridPosition.x + dir.x, 0, m_gridSize[0]) * m_step,
            m_player.position.y,
            Mathf.Clamp(m_onGridPosition.y + dir.y, 0, m_gridSize[1]) * m_step
        );
        StopAllCoroutines();
        StartCoroutine(LerpMove(currentPos, targetPos));
    }

    IEnumerator LerpMove(Vector3 source, Vector3 target)
    {
        for (int i = 1; i <= 100; i++)
        {
            m_player.position = Vector3.Lerp(source, target, i / 100f);
            yield return new WaitForSeconds(1f / m_speed);
        }
    }
}
