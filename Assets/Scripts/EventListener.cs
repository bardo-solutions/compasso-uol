using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public UnityEvent<KeyboardEvent> OnKeyboardEvent = new UnityEvent<KeyboardEvent>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            // up
            OnKeyboardEvent.Invoke(KeyboardEvent.Up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            // down
            OnKeyboardEvent.Invoke(KeyboardEvent.Down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            // left
            OnKeyboardEvent.Invoke(KeyboardEvent.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            // right
            OnKeyboardEvent.Invoke(KeyboardEvent.Right);
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            // start
            OnKeyboardEvent.Invoke(KeyboardEvent.Start);
        }
    }
}
