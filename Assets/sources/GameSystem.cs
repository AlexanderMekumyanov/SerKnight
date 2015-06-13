using System;
using UnityEngine;
public class GameSystem
{
    private static GameSystem instance;
    private PlayerScript player;

    public static GameSystem GetInstance()
    {
        if (instance == null)
        {
            return instance = new GameSystem();
        }
        return instance;
    }

    public GameSystem()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public PlayerScript Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
}
