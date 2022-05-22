using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public float health;
    public float mana;
    public float stamina;
    public Position position = new Position();
    public int budget;
    public List<Item> inventory = new List<Item>();
}
