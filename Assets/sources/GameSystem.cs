using System;
using UnityEngine;
public class GameSystem
{
    private static GameSystem instance;
    

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
        
    }

   
}
