using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Collected : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ExecuteEvents.ExecuteHierarchy<CollectionHandler>(gameObject, null, (f, a) => f.OnCollected());
        Destroy(gameObject);
    }
}
