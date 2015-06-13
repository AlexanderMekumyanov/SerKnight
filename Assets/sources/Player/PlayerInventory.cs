using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerInventory
{
    static PlayerInventory instance = null;

    private Dictionary<string, bool> items;
    private Dictionary<string, GameObject> weapons;

    private GameObject currentWeapon;

    public PlayerInventory()
    {
        items = new Dictionary<string, bool>();
        weapons = new Dictionary<string, GameObject>();
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

    public void AddNewWeapon(string name, GameObject weapon)
    {
        weapons.Add(name, weapon);
    }

    public void EquiptWeapon(string name)
    {
        currentWeapon = weapons[name];
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
