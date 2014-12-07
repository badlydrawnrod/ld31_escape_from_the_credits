using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Reaper : MonoBehaviour
{
    public bool reapWhenRising;
    public bool reapWhenFalling;

    void OnTriggerExit2D(Collider2D other)
    {
        if (ShouldReap(other.transform))
        {
            ExecuteEvents.ExecuteHierarchy<PlayerKilledHandler>(other.gameObject, null, (f, a) => f.OnPlayerKilled());
            Destroy(other.gameObject);
        }
    }

    bool ShouldReap(Transform other)
    {
        return (reapWhenFalling && other.position.y < transform.position.y) || (reapWhenRising && other.position.y > transform.position.y);
    }
}
