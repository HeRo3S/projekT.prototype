using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public int budget;
    public List<Item> inventory = new List<Item>();
}
