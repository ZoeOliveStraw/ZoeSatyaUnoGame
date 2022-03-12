using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cpuPrefab;
    [SerializeField] private List<Player> players = new List<Player>();
    private int numOfPlayers;
    private string name;
    private float cpuYLocation = 3.0f;
    private Controls _controls;
    private Player currentPlayer;
    private int currentPlayerIndex = -1;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Debug.NextTurn.performed += ctx => NextPlayer();
    }

    void Start()
    {
        numOfPlayers = GameInfo._instance.GetCpuPlayers();
        name = GameInfo._instance.GetName();
        InitializeGame();
    }
    private void InitializeGame()
    {
        List<float[]> xPositions = new List<float[]>()
        {
            new float[] {0, 0, 0},
            new float[] {-3, 3, 0},
            new float[] {-5.75f, 0, 5.75f}
        };
        switch (numOfPlayers)
        {
            case 1:
                PlaceCPUPlayers(xPositions[0]);
                break;
            case 2:
                PlaceCPUPlayers(xPositions[1]);
                break;
            case 3:
                PlaceCPUPlayers(xPositions[2]);
                break;
        }
        NextPlayer();
    }
    private void PlaceCPUPlayers(float[] xPositions)
    {
        for (int i = 1; i <= numOfPlayers; i++)
        {
            CpuPlayer nextPlayer = Instantiate(cpuPrefab,
                new Vector3(xPositions[i-1], 3, 0),
                Quaternion.identity).GetComponent<CpuPlayer>();
            nextPlayer.gameObject.transform.parent = this.transform;
            nextPlayer.gameObject.transform.name = $"CPU {i}";
            players.Add(nextPlayer);
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void NextPlayer()
    {
        if (currentPlayer == null)
        {
            currentPlayerIndex = 0;
        }
        else if (currentPlayerIndex < players.Count - 1)
        {
            currentPlayer.TurnEnd();
            currentPlayerIndex++;
        }
        else
        {
            currentPlayer.TurnEnd();
            currentPlayerIndex = 0;
        }
        currentPlayer = players[currentPlayerIndex];
        currentPlayer.TurnStart();
    }
}
