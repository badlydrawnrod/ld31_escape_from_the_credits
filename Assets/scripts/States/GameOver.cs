using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class GameOver : State, IAbandonHandler
{
    public State main;
    public State playing;
    public GameObject gameOverPrefab;

    private GameObject gameOver;
    private float timeScale;

    public override void Enter()
    {
        gameOver = Instantiate(gameOverPrefab) as GameObject;
        gameOver.transform.SetParent(transform, false);
        timeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        Time.timeScale = timeScale;
        Destroy(gameOver);
        gameOver = null;
    }

    public override void ChildExited()
    {
        gameOver.SetActive(true);
    }

    public void OnAbandon()
    {
        ChangeState(main);
    }
}
