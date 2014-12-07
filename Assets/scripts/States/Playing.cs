using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class Playing : State, PlayerKilledHandler, PlayerWonHandler
{
    public ScrollUp scrollUp;
    public State main;
    public State gameLost;
    public State gameWon;
    public GameObject playingPrefab;
    public AudioClip deathSound;

    private GameObject playing;

    public override void Enter()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        playing = Instantiate(playingPrefab) as GameObject;
        playing.transform.SetParent(transform, false);
        scrollUp.enabled = true;
    }

    public override void Exit()
    {
        Destroy(playing);
        playing = null;
        scrollUp.enabled = false;
    }

    public override void ChildExited()
    {
        scrollUp.enabled = true;
    }

    public void OnPlayerKilled()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        scrollUp.enabled = false;
        ChangeState(gameLost);
    }

    public void OnPlayerWon()
    {
        scrollUp.enabled = false;
        ChangeState(gameWon);
    }
}
