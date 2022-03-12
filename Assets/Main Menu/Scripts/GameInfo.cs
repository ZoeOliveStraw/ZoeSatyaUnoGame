using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField][Range(1,3)] private int cpuPlayers;
    public static GameInfo _instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetName(string _name)
    {
        name = _name;
    }
    public string GetName()
    {
        return name;
    }
    public void SetCpuPlayers(int _players)
    {
        cpuPlayers = _players;
    }

    public int GetCpuPlayers()
    {
        return cpuPlayers;
    }

    public void Initialize(string _name, int _cpuPlayers)
    {
        cpuPlayers = _cpuPlayers;
        name = _name;
    }
}
