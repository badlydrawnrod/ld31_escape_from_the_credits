using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ScoringAndStatus : MonoBehaviour, CollectionHandler
{
    public AudioClip pickupCoin;
    public Text scoreValue;

    private int _score;

    private int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreValue.text = _score.ToString();
        }
    }

    void Awake()
    {
        score = 0;
    }

    public void OnCollected()
    {
        AudioSource.PlayClipAtPoint(pickupCoin, Camera.main.transform.position);
        score++;
    }
}
