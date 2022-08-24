using UnityEngine.Events;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public KeyCode key=KeyCode.J;
    private bool hasPeople = false;
    public string playerName = "PlayerB";
    public UnityEvent events;
    void Update()
    {
        if (hasPeople)
        {
            if (Input.GetKeyDown(key))
            {
                events?.Invoke();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("OnTriggerEnter2D");
        if (other.name == playerName)
        {
            hasPeople = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == playerName)
        {
            hasPeople = false;
        }
    }
}
