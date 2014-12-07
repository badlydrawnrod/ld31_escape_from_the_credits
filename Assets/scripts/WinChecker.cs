using UnityEngine;
using UnityEngine.EventSystems;

public class WinChecker : MonoBehaviour
{
    bool won;

    void Start()
    {
        won = false;
    }

    void FixedUpdate()
    {
        if (!won)
        {
            won = Camera.main.transform.position.y < transform.position.y;
            if (won)
            {
                ExecuteEvents.ExecuteHierarchy<PlayerWonHandler>(gameObject, null, (f, a) => f.OnPlayerWon());
            }
        }
    }
}
