using UnityEngine.Events;
using UnityEngine.EventSystems;

interface CollectionHandler : IEventSystemHandler
{
    void OnCollected();
}