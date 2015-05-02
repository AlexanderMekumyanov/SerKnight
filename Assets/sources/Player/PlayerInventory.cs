using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PlayerInventory
{
    static PlayerInventory instance = null;

    private Dictionary<string, bool> items;

    public PlayerInventory()
    {
        items = new Dictionary<string, bool>();
    }

    public static PlayerInventory GetPlayerInventory()
    {
        if (instance == null)
        {
            return instance = new PlayerInventory();
        }
        return instance;
    }

    public void AddNewItem(string id)
    {
        items.Add(id, true);
    }

    public bool IsItem(string id)
    {
        // TODO добавить нормальные итемы
        bool isHave = false;
        if (items.TryGetValue(id, out isHave))
        {
            return true;
        }
        return false;
    }
}
