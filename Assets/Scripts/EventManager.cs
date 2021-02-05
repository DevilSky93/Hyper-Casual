using System.Collections;
using System.Collections.Generic;
using Events.Bool;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private bool gameStarted;

    [SerializeField] private EventBool updateGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted)
        {
            updateGame.Raise(gameStarted);
        }
    }

    public void StartGame(bool gameStart)
    {
        gameStarted = gameStart;
    }
}
