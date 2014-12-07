using UnityEngine.Events;
using UnityEngine.EventSystems;

interface PlayerKilledHandler : IEventSystemHandler
{
    void OnPlayerKilled();
}