using UnityEngine.Events;
using UnityEngine.EventSystems;

interface PlayerWonHandler : IEventSystemHandler
{
    void OnPlayerWon();
}